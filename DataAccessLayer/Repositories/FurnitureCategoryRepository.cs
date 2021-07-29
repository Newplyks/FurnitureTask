using DataAccessLayer.Infrastructure;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class FurnitureCategoryRepository : IFurnitureCategoryRepository
    {
        private readonly StorageDbContext _db;

        public FurnitureCategoryRepository(StorageDbContext db)
        {
            _db = db;
        }

        async public Task CreateAsync(FurnitureCategory item)
        {
            await _db.FurnitureCategories.AddAsync(item);
        }

        async public Task DeleteAsync(FurnitureCategory item)
        {
            _db.FurnitureCategories.Remove(item);
        }

        async public Task<IEnumerable<FurnitureCategory>> GetAll()
        {
            return await _db.FurnitureCategories.ToListAsync();
        }

        async public Task<FurnitureCategory> GetAsync(Guid id)
        {
            return await _db.FurnitureCategories.FindAsync(id);

        }

        async public Task UpdateAsync(FurnitureCategory item)
        {
            _db.FurnitureCategories.Update(item);
        }
    }
}
