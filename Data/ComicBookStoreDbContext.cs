using Dotnet_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicBookStore.Data
{
    public class ComicBookStoreDbContext : DbContext
    {
        public ComicBookStoreDbContext(DbContextOptions<ComicBookStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalDetail> RentalDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ComicSystem.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComicBook>().HasData(
                new ComicBook { ComicBookID = 1, Title = "Conan", Author = "Gosho Aoyama", PricePerDay = 1.5m },
                new ComicBook { ComicBookID = 2, Title = "Doraemon", Author = "Fujiko F. Fujio", PricePerDay = 1.2m }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, FullName = "Nguyen Hung", PhoneNumber = "0123456789", RegistrationDate = DateTime.Parse("2024-01-01") }
            );

            modelBuilder.Entity<Rental>().HasData(
                new Rental { RentalID = 1, CustomerID = 1, RentalDate = DateTime.Parse("2024-01-10"), ReturnDate = DateTime.Parse("2024-01-20"), Status = "Completed" }
            );

            modelBuilder.Entity<RentalDetail>().HasData(
                new RentalDetail { RentalDetailID = 1, RentalID = 1, ComicBookID = 1, Quantity = 1, PricePerDay = 1.5m },
                new RentalDetail { RentalDetailID = 2, RentalID = 1, ComicBookID = 2, Quantity = 3, PricePerDay = 1.2m }
            );
        }
    }
}