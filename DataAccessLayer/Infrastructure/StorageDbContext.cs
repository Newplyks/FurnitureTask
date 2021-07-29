using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccessLayer.Infrastructure
{
    public class StorageDbContext: DbContext, IDbContext
    {
        public DbSet<Furniture> Furniture { get; set; }
        public DbSet<FurnitureCategory> FurnitureCategories { get; set; }
        public DbSet<FurnitureImage> FurnitureImages { get; set; }


        public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Furniture>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<FurnitureCategory>().HasIndex(x => x.Id).IsUnique();
            SeedData(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBefoSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBefoSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBefoSaving()
        {
            var timestamp = DateTime.UtcNow;

            ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified ||
                            e.State == EntityState.Added)
                .Select(e => e.Entity)
                .Cast<BaseEntity>()
                .ToList()
                .ForEach(e => e.ModifiedDate = timestamp);

            ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity)
                .Cast<BaseEntity>()
                .ToList()
                .ForEach(e => e.CreatedDate = timestamp);
        }

        public void EnsureCreated()
        {
            Database.EnsureCreated();
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            string[] titles = new string[] { "Шкафы-купе", "Мебель для спальни", "Мебель для гостиной", "Кухонная мебель", "Офисная мебель", "Мебель для ресторанов и торговых помещений" };
            var categories = new List<FurnitureCategory>();
            foreach(string item  in titles)
            {
                categories.Add(new FurnitureCategory() { Id = Guid.NewGuid(), Title = item, CreatedDate = new DateTime(), ModifiedDate = new DateTime() });
            }

            modelBuilder.Entity<FurnitureCategory>().HasData(categories);
        }
    }
}
