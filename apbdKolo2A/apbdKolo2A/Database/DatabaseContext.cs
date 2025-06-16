using apbdKolo2A.Models;
using Microsoft.EntityFrameworkCore;

namespace apbdKolo2A.Database;

public class DatabaseContext : DbContext
{
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Models.Program> Programs { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer(){CustomerId = 1, FirstName = "Jan", LastName = "Kowalski", PhoneNumber = "111-222-333"},
            new Customer(){CustomerId = 2, FirstName = "Krzysztof", LastName = "Zalewski", PhoneNumber = "333-444-555"},
            new Customer(){CustomerId = 3, FirstName = "Aleksander", LastName = "Ciesla", PhoneNumber = "666-777-888"}
        });
        modelBuilder.Entity<Models.Program>().HasData(new List<Models.Program>
        {
            new Models.Program(){ProgramId = 1, Name = "Szybkie", DurationMinutes = 20, TemperatureCelsius = 50},
            new Models.Program(){ProgramId = 2, Name = "Delikatne", DurationMinutes = 120, TemperatureCelsius = 30},
            new Models.Program(){ProgramId = 3, Name = "Sportowe", DurationMinutes = 60, TemperatureCelsius = 40}
        });
        modelBuilder.Entity<WashingMachine>().HasData(new List<WashingMachine>
        {
            new WashingMachine(){WashingMachineId = 1, MaxWeight = 20.00, SerialNumber = "PDW123456"},
            new WashingMachine(){WashingMachineId = 2, MaxWeight = 12.00, SerialNumber = "PDW987654"},
            new WashingMachine(){WashingMachineId = 3, MaxWeight = 5.50, SerialNumber = "PDW673028"}
        });
        modelBuilder.Entity<AvailableProgram>().HasData(new List<AvailableProgram>
        {
            new AvailableProgram(){AvailableProgramId = 1 ,WashingMachineId = 1, ProgramId = 1, Price = 10.99},
            new AvailableProgram(){AvailableProgramId = 2, WashingMachineId = 1, ProgramId = 2, Price = 12.50 },
            new AvailableProgram(){AvailableProgramId = 3, WashingMachineId = 2, ProgramId = 2, Price = 14.00},
            new AvailableProgram(){AvailableProgramId = 4, WashingMachineId = 2, ProgramId = 3, Price = 11.60},
            new AvailableProgram(){AvailableProgramId = 5, WashingMachineId = 3, ProgramId = 1, Price = 20.00},
            new AvailableProgram(){AvailableProgramId = 6, WashingMachineId = 3, ProgramId = 3, Price = 6.60}
        });
        modelBuilder.Entity<PurchaseHistory>().HasData(new List<PurchaseHistory>
        {
            new PurchaseHistory(){AvailableProgramId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2021-01-01"), Rating = 5},
            new PurchaseHistory(){AvailableProgramId = 2, CustomerId = 1, PurchaseDate = DateTime.Parse("2022-01-01"), Rating = 2},
            new PurchaseHistory(){AvailableProgramId = 3, CustomerId = 2, PurchaseDate = DateTime.Parse("2022-02-06"), Rating = 6}
        });
    }

}