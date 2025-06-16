using Microsoft.EntityFrameworkCore;
using Probny2025ZRozwiazaniem.Models;

namespace Probny2025ZRozwiazaniem.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<ProductsOrdered> ProductsOrdereds { get; set; }

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

        modelBuilder.Entity<ProductsOrdered>().HasData(new List<ProductsOrdered>()
        {
            new ProductsOrdered(){ProductId = 1, OrderId = 1, Amount = 3},
            new ProductsOrdered(){ProductId = 1, OrderId = 2, Amount = 4},
            new ProductsOrdered(){ProductId = 3, OrderId = 3, Amount = 5},
            new ProductsOrdered(){ProductId = 1, OrderId = 3, Amount = 6},
            new ProductsOrdered(){ProductId = 2, OrderId = 2, Amount = 7},
            new ProductsOrdered(){ProductId = 2, OrderId = 3, Amount = 9},
        });
    }
}