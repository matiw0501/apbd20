using System.Diagnostics.Contracts;
using apbdKolos2B.Models;
using Microsoft.EntityFrameworkCore;

namespace apbdKolos2B.Database;

public class DatabaseContext : DbContext
{

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Concert> Contracts { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    public DbSet<TicketConcert> TicketConcerts { get; set; }
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer(){CustomerId = 1, FirstName = "Jane", LastName = "Kowalski", PhoneNumber = "999-999-999"},
            new Customer(){CustomerId = 2, FirstName = "Krzysztof", LastName = "Zalewski", PhoneNumber = "777-777-777"},
            new Customer(){CustomerId = 3, FirstName = "Grzegorz", LastName = "Floryda", PhoneNumber = null}
        });

        modelBuilder.Entity<Concert>().HasData(new List<Concert>
        {
            new Concert(){ConcertId = 1, Name = "Pielgrzymka", Date = DateTime.Parse("2025-02-01"), AvailableTickets = 20},
            new Concert(){ConcertId = 2, Name = "Juwenalia", Date = DateTime.Parse("2025-06-05"), AvailableTickets = 100},
            new Concert(){ConcertId = 3, Name = "Urysnalia", Date = DateTime.Parse("2025-07-05"), AvailableTickets = 300},
        });

        modelBuilder.Entity<Ticket>().HasData(new List<Ticket>
        {
            new Ticket(){TicketId = 1, SerialNumber = "PDW1111", SeatNumber = 200},
            new Ticket(){TicketId = 2, SerialNumber = "PDW2222", SeatNumber = 15},
            new Ticket(){TicketId = 3, SerialNumber = "PDW3333", SeatNumber = 20},
        });

        modelBuilder.Entity<TicketConcert>().HasData(new List<TicketConcert>
        {
            new TicketConcert(){TicketConcertId = 1, TicketId = 1, ConcertId = 1, Price = 15.99},
            new TicketConcert(){TicketConcertId = 2, TicketId = 1, ConcertId = 2, Price = 20.99},
            new TicketConcert(){TicketConcertId = 3, TicketId = 2, ConcertId = 3, Price = 27.87},
            new TicketConcert(){TicketConcertId = 4, TicketId = 3, ConcertId = 1, Price = 123.45},
            new TicketConcert(){TicketConcertId = 5, TicketId = 3, ConcertId = 2, Price = 112.99}
        });

        modelBuilder.Entity<PurchasedTicket>().HasData(new List<PurchasedTicket>
        {
            new PurchasedTicket(){TicketConcertId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-02-01")},
            new PurchasedTicket(){TicketConcertId = 1, CustomerId = 2, PurchaseDate = DateTime.Parse("2025-06-09")},
            new PurchasedTicket(){TicketConcertId = 2, CustomerId = 2, PurchaseDate = DateTime.Parse("2025-09-19")},
            new PurchasedTicket(){TicketConcertId = 2, CustomerId = 3, PurchaseDate = DateTime.Parse("2025-03-14")},
            new PurchasedTicket(){TicketConcertId = 3, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-01-30")},
            new PurchasedTicket(){TicketConcertId = 3, CustomerId = 3, PurchaseDate = DateTime.Parse("2025-12-17")}
        });

    }


}