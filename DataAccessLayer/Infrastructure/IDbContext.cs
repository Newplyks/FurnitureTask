using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    public interface IDbContext
    {
        DbSet<Furniture> Furniture { get; set; }
        DbSet<FurnitureCategory> FurnitureCategories { get; set; }
        DbSet<FurnitureImage> FurnitureImages { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void EnsureCreated();
    }
}
