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
    public class FurnitureRepository : IFurnitureRepository
    {
        private readonly StorageDbContext _db;

        public FurnitureRepository(StorageDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Furniture item)
        {
            await _db.Furniture.AddAsync(item);
        }

        public async Task DeleteAsync(Furniture item)
        {
            _db.Furniture.Remove(item);
        }

        public async Task<IEnumerable<Furniture>> GetAll(int skip, int size)
        {
            return await _db.Furniture.Skip(skip).Take(size).ToListAsync();
        }

        public async Task<Furniture> GetAsync(Guid id)
        {
            return await _db.Furniture
                .Include(item => item.Category)
                .Include(item => item.Images)
                .Where(item => item.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetCountFurniture()
        {
            return _db.Furniture.Count();
        }

        public async Task UpdateAsync(Furniture item)
        {
            _db.Furniture.Update(item);
        }
    }
}
