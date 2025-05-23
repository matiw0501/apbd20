using Microsoft.EntityFrameworkCore;
using Tutorial5.Models;

namespace Tutorial5.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

   
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors().EnableDetailedErrors();
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(a =>
        {
            a.ToTable("Author");
            
            a.HasKey(e => e.AuthorId);
            a.Property(e => e.FirstName).HasMaxLength(100);
            a.Property(e => e.LastName).HasMaxLength(200);
        });

        modelBuilder.Entity<Author>().HasData(new List<Author>()
        {
            new Author() { AuthorId = 1, FirstName = "Jane", LastName = "Doe"},
            new Author() { AuthorId = 2, FirstName = "John", LastName = "Doe"},
        });
        
        modelBuilder.Entity<Book>().HasData(new List<Book>()
        {
            new Book() { BookId = 1, Name = "Book 1", Price = 10.2 },
            new Book() { BookId = 2, Name = "Book 2", Price = 123.2 },
        });
        
        modelBuilder.Entity<BookAuthor>().HasData(new List<BookAuthor>()
        {
            new BookAuthor() { AuthorId = 1, BookId = 1, Notes = "n1" },
            new BookAuthor() { AuthorId = 2, BookId = 1, Notes = "n2" },
        });
        
        modelBuilder.Entity<PrescriptionMedicament>()
            .HasKey(pm => new { pm.IdPrescription, pm.IdMedicament });

        
        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdPrescription);

       
        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne(pm => pm.Medicament)
            .WithMany(m => m.PrescriptionsMedicaments)
            .HasForeignKey(pm => pm.IdMedicament);

      
        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Patient)
            .WithMany(pa => pa.Prescriptions)
            .HasForeignKey(p => p.PatientId);

        
        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Doctor)
            .WithMany()
            .HasForeignKey(p => p.DoctorId);
        
       
         modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "Anna", LastName = "Kowalska", Email = "anna.k@clinic.com" },
            new Doctor { IdDoctor = 2, FirstName = "Tomasz", LastName = "Nowak", Email = "t.nowak@clinic.com" }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "Jan", LastName = "Kowalski", BirthDate = new DateTime(1990, 1, 1) },
            new Patient { IdPatient = 2, FirstName = "Maria", LastName = "Wiśniewska", BirthDate = new DateTime(1985, 5, 20) }
        );

        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1, Name = "Ibuprom", Description = "Painkiller", Type = "Tablet" },
            new Medicament { IdMedicament = 2, Name = "Paracetamol", Description = "Fever reducer", Type = "Tablet" },
            new Medicament { IdMedicament = 3, Name = "Amoxicillin", Description = "Antibiotic", Type = "Capsule" }
        );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                IdPrescription = 1,
                Date = new DateTime(2024, 1, 1),
                DueDate = new DateTime(2024, 1, 14),
                PatientId = 1,
                DoctorId = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = new DateTime(2024, 2, 10),
                DueDate = new DateTime(2024, 2, 20),
                PatientId = 2,
                DoctorId = 2
            }
        );

        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament
            {
                IdPrescription = 1,
                IdMedicament = 1,
                Dose = 2,
                Details = "Take after meal"
            },
            new PrescriptionMedicament
            {
                IdPrescription = 1,
                IdMedicament = 2,
                Dose = 1,
                Details = "Before sleep"
            },
            new PrescriptionMedicament
            {
                IdPrescription = 2,
                IdMedicament = 3,
                Dose = 3,
                Details = "Morning only"
            }
        );
        
    }
}