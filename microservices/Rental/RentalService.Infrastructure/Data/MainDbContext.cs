using Microsoft.EntityFrameworkCore;
using Commerce.Infrastructure.EfCore;
using RentalService.AppCore.Core;

namespace RentalService.Infrastructure.Data
{
    public class MainDbContext : AppDbContextBase
    {
        private const string Schema = "prod";

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Rental> Rentals { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension(Consts.UuidGenerator);

            // Rental
            modelBuilder.Entity<Rental>().ToTable("Rentals", Schema);
            modelBuilder.Entity<Rental>().HasKey(x => x.Id);
            modelBuilder.Entity<Rental>().Property(x => x.Id).HasColumnType("uuid")
                .HasDefaultValueSql(Consts.UuidAlgorithm);

            modelBuilder.Entity<Rental>().Property(x => x.CustomerId).HasColumnType("uuid");
            modelBuilder.Entity<Rental>().Property(x => x.ProductId).HasColumnType("uuid");
            modelBuilder.Entity<Rental>().Property(x => x.Created).HasDefaultValueSql(Consts.DateAlgorithm);

            modelBuilder.Entity<Rental>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Rental>().Ignore(x => x.DomainEvents);
        }
    }
}
