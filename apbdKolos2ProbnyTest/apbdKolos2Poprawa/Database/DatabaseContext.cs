using Microsoft.EntityFrameworkCore;

namespace apbdKolos2ProbnyTest.Database;

public class DatabaseContext : DbContext
{


    // public DbSet<> {get; set;}
    // public DbSet<> {get; set;}
    // public DbSet<> {get; set;}
    // public DbSet<> {get; set;}
    // public DbSet<> {get; set;}
    
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<>().HasData(new List<>
        // {
        //     
        // });
        //
        //
        // modelBuilder.Entity<>().HasData(new List<>
        // {
        //     
        // });
        //
        //
        // modelBuilder.Entity<>().HasData(new List<>
        // {
        //     
        // });
        //
        //
        // modelBuilder.Entity<>().HasData(new List<>
        // {
        //     
        // });
        //
        // modelBuilder.Entity<>().HasData(new List<>
        // {
        //     
        // });

    }

}