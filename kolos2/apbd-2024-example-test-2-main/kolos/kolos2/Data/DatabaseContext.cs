
using kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolos2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Ticket_Concert> Ticket_Concerts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Concert>().HasData(new List<Concert>
        {
            new Concert()
            {
                ConcertId = 1,
                AvailableTickets = 15,
                Name = "Juwenalia"
            },
            new Concert()
            {
                ConcertId = 2,
                AvailableTickets = 10,
                Name = "Ursynalia"
            },
            new Concert()
            {
                ConcertId = 3,
                AvailableTickets = 5,
                Name = "Mokotonalia"
            }
        });

        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer()
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "555-555-5555"
            },
            new Customer()
            {
                CustomerId = 2,
                FirstName = "Jane",
                LastName = "Doe",
                PhoneNumber = "555-555-5555"
            },
            new Customer()
            {
                CustomerId = 3,
                FirstName = "Marry",
                LastName = "Starsky",
                PhoneNumber = "444-4444-4444"
            }
        });

        modelBuilder.Entity<Ticket>().HasData(

            new Ticket {
                TicketId = 1,
                SerialNumber = "SN132836126",
                SeatNumber = 124 
            },

            new Ticket 
            {
                TicketId = 2,
                SerialNumber = "SN126846192",
                SeatNumber = 330 }
        );


        modelBuilder.Entity<Ticket_Concert>().HasData(new List<Ticket_Concert>{
            new Ticket_Concert
                { 
                    TicketConcertId = 1,
                    TicketId = 1,
                    ConcertId = 1,
                    Price = 12
                },
            new Ticket_Concert 
                { TicketConcertId = 2,
                    TicketId = 2,
                    ConcertId = 2,
                    Price = 10 }

        }
        );
        modelBuilder.Entity<Purchase>().HasData(new List<Purchase>{
            new Purchase
            {
                TicketConcertId = 1,

                CustomerId = 1,

                PurchaseDate = new DateTime(2020, 05, 05),

            },
            new Purchase()
            {
                TicketConcertId = 2,
                CustomerId = 1,
                PurchaseDate = new DateTime(2021, 01, 02),
            }

        });

    }
        
        
        
    }