using apbdKolos2B.DTOs;
using apbdKolos2B.Exceptions;
using apbdKolos2B.Models;
using Microsoft.EntityFrameworkCore;

namespace apbdKolos2B.Database;

public class DbService  : IDbService
{
    
    
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CustomerPurchasesDTO> GetPurchases(int id)
    {
        var customerPurchases = await _context.Customers.Where(c => c.CustomerId == id).Select(e =>
            new CustomerPurchasesDTO
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                PhoneNumber = e.PhoneNumber,
                Purchases = e.PurchasedTickets.Select(a => new PurchaseDTO()
                {
                    
                    Date = a.PurchaseDate,
                    Price = a.TicketConcert.Price,
                    
                    Ticket = new TicketDTO
                    {
                        Serial = a.TicketConcert.Ticket.SerialNumber,
                        SeatNumber = a.TicketConcert.Ticket.SeatNumber,
                    },
                    Concert = new ConcertDTO
                    {
                        Name = a.TicketConcert.Concert.Name,
                        Date = a.TicketConcert.Concert.Date,
                    }
                }).ToList()
                
            }).FirstOrDefaultAsync();

        if (customerPurchases is null)
        {
            throw new NotFoundException("Null mordzia");
        }

        return  customerPurchases;
    }

    public async Task AddCustomer(AddCustomer addCustomer)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var customer = await _context.Customers.Include(customer => customer.PurchasedTickets)
                .ThenInclude(purchasedTicket => purchasedTicket.TicketConcert)
                .ThenInclude(ticketConcert => ticketConcert.Concert).FirstOrDefaultAsync(e => e.CustomerId == addCustomer.Customer.CustomerId);
            if (customer == null)
            {
                customer = new Customer()
                {
                    FirstName = addCustomer.Customer.FirstName,
                    LastName = addCustomer.Customer.LastName,
                    PhoneNumber = addCustomer.Customer.Phone,
                };
                await _context.Customers.AddAsync(customer);
            }

            
            foreach (var purchase in addCustomer.Purchases)
            {
                var concert = await _context.Contracts.FirstOrDefaultAsync(e => e.Name == purchase.ConcertName);
                if (concert == null) throw new NotFoundException("Concert not found");
                var ticketCount = customer.PurchasedTickets.Count(e => purchase.ConcertName == e.TicketConcert.Concert.Name);
                if (ticketCount >= 5) throw new InvalidOperationException("Maximum number of tickets reached");
                var ticket = new Ticket()
                {
                    SeatNumber = purchase.SeatNumber, SerialNumber = "SN" + purchase.SeatNumber,
                };
                await _context.Tickets.AddAsync(ticket);
                var ticketConcert = new TicketConcert()
                {
                    Ticket = ticket, Concert = concert, Price = purchase.Price,
                };
                await _context.TicketConcerts.AddAsync(ticketConcert);
                var purchasedTicket = new PurchasedTicket()
                {
                    Customer = customer, PurchaseDate = DateTime.Today, TicketConcert = ticketConcert
                };
                await _context.PurchasedTickets.AddAsync(purchasedTicket);
            }
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }


}