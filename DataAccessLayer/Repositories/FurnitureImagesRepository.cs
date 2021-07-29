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
    public class FurnitureImagesRepository : IFurnitureImagesRepository
    {
        private readonly StorageDbContext _db;

        public FurnitureImagesRepository(StorageDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(FurnitureImage item)
        {
            await  _db.FurnitureImages.AddAsync(item);
        }

        public async Task DeleteAsync(FurnitureImage item)
        {
            _db.FurnitureImages.Remove(item);
        }

        public async Task<FurnitureImage> GetAsync(Guid id)
        {
            return await _db.FurnitureImages.FindAsync(id);
        }

        public async Task<IEnumerable<FurnitureImage>> GetByFurniture(Guid furnitureId)
        {
            return await _db.FurnitureImages.Where(item => item.FurnitureId == furnitureId).ToListAsync();
        }

        public async Task UpdateAsync(FurnitureImage item)
        {
            _db.FurnitureImages.Update(item);
        }
    }
}
