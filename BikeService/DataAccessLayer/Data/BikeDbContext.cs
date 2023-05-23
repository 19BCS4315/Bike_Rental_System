

using BikeRentalSystem.BikeService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalSystem.BikeService.DataAccessLayer.Data
{
    public class BikeDbContext:DbContext
    {
        public BikeDbContext(DbContextOptions<BikeDbContext>options):base(options) { }
        public virtual DbSet<Bike> Bikes { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>().HasKey(b => b.BikeId);
            modelBuilder.Entity<Bike>().Property(b => b.BikeType).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Bike>().Property(b => b.Brand).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Bike>().Property(b => b.Model).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Bike>().Property(b => b.PurchaseDate).HasColumnType("dateTime");
            modelBuilder.Entity<Bike>().Property(b => b.PurchasePrice).HasColumnType("decimal(18 ,2)");
            modelBuilder.Entity<Bike>().Property(b => b.RentalPricePerHour).HasColumnType("decimal(18 ,2)");
            modelBuilder.Entity<Bike>().Property(b => b.RentalPricePerDay).HasColumnType("decimal(18 ,2)");
            modelBuilder.Entity<Bike>().Property(b => b.RentalPricePerWeek).HasColumnType("decimal(18 ,2)");
            modelBuilder.Entity<Bike>().Property(b => b.AvailableQuantity).IsRequired();

            base.OnModelCreating(modelBuilder);

        }


    }
}
