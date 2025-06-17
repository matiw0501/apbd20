using apbdKolos2ProbnyTest.Models;
using Microsoft.EntityFrameworkCore;

namespace apbdKolos2ProbnyTest.Database;

public class DatabaseContext : DbContext
{


    public DbSet<Backpack> Backpacks {get; set;}
    public DbSet<Character> Characters {get; set;}
    public DbSet<CharacterTitle> CharacterTitles {get; set;}
    public DbSet<Item> Items {get; set;}
    public DbSet<Title> Titiles {get; set;}
    
    
    protected DatabaseContext() : base()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item(){ItemId = 1, Name = "Puszka", Weight = 3},
            new Item(){ItemId = 2, Name = "Latarka", Weight = 1},
            new Item(){ItemId = 3, Name = "Zapalniczka", Weight = 1},
        });
        
        
        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
                new Title(){TitileId = 1, Name = "Technik"},
                new Title(){TitileId = 2, Name = "Inzynier"},
                new Title(){TitileId = 3, Name = "Kucharz"},
        });
        
        
        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character(){CharacterId = 1, FirstName = "Jan", LastName = "Kowalski", CurrentWeight = 60, MaxWeight = 80},
            new Character(){CharacterId = 2, FirstName = "Krzysztof", LastName = "Zalewski", CurrentWeight = 50, MaxWeight = 65},
            new Character(){CharacterId = 3, FirstName = "Jakub", LastName = "Cash", CurrentWeight = 65, MaxWeight = 92},
        });
        
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack(){CharacterdId = 1, ItemId = 1, Amount = 3},
            new Backpack(){CharacterdId = 1, ItemId = 2, Amount = 1},
            new Backpack(){CharacterdId = 1, ItemId = 3, Amount = 2},
            new Backpack(){CharacterdId = 2, ItemId = 1, Amount = 2},
            new Backpack(){CharacterdId = 2, ItemId = 3, Amount = 1},
            new Backpack(){CharacterdId = 3, ItemId = 1, Amount = 8},
            new Backpack(){CharacterdId = 3, ItemId = 3, Amount = 6},
        });
        
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>
        {
            new CharacterTitle(){CharacterId = 1, TitileId = 1, AcquiredAt = DateTime.Parse("2021-01-01")},
            new CharacterTitle(){CharacterId = 1, TitileId = 2, AcquiredAt = DateTime.Parse("2022-03-16")},
            new CharacterTitle(){CharacterId = 2, TitileId = 3, AcquiredAt = DateTime.Parse("2021-09-12")},
            new CharacterTitle(){CharacterId = 3, TitileId = 2, AcquiredAt = DateTime.Parse("2023-11-23")},
            new CharacterTitle(){CharacterId = 3 ,TitileId = 3, AcquiredAt = DateTime.Parse("2022-12-24")},
        });

    }

}