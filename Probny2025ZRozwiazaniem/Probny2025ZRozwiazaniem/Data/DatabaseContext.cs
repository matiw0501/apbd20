using Microsoft.EntityFrameworkCore;
using Probny2025ZRozwiazaniem.Models;

namespace Probny2025ZRozwiazaniem.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Orders> Orders { get; set; }
 //   public DbSet<ProductOrder> ProductOrders { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(new List<Client>()
        {
            new Client(){ClientId = 1, FirstName = "Jan", LastName = "Kowalski"},
            new Client(){ClientId = 2, FirstName = "Michal", LastName = "Wisniewski"},
            new Client(){ClientId = 3, FirstName = "Krzysztof", LastName = "Blachowicz"},
        });

        modelBuilder.Entity<Product>().HasData(new List<Product>()
        {
            new Product(){ProductId = 1, Name = "CD", Price = 15.99},
            new Product(){ProductId = 2, Name = "Zmywarka", Price = 200.20},
            new Product(){ProductId = 3, Name = "Wanna", Price = 50.30},
            new Product(){ProductId = 4, Name = "Prysznic", Price = 35.89}
        });

        modelBuilder.Entity<Status>().HasData(new List<Status>()
        {
            new Status(){StatusId = 1, Name = "Zlozony"},
            new Status(){StatusId = 2, Name = "W trakcie"},
            new Status(){StatusId = 3, Name = "Wykonany"}
            
        });

        modelBuilder.Entity<Orders>().HasData(new List<Orders>()
        {
            new Orders(){OrderId = 1, ClientId = 1, OrderedAt = DateTime.Parse("2025-06-15"), FulfilledAt = null, StatusId = 1},
            new Orders(){OrderId = 2, ClientId = 2, OrderedAt = DateTime.Parse("2025-01-02"), FulfilledAt = DateTime.Parse("2025-04-20"), StatusId = 3},
            new Orders(){OrderId = 3, ClientId = 3, OrderedAt = DateTime.Parse("2025-02-01"), FulfilledAt = null, StatusId = 2}
        });
    }
}