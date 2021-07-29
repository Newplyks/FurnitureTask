using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StorageDbContext _db;
        private IFurnitureRepository _furnitureRepository;
        private IFurnitureCategoryRepository _furnitureCategoryRepository;
        private IFurnitureImagesRepository _furnitureImagesRepository;


        public UnitOfWork(StorageDbContext db)
        {
            _db = db;

        }

        public IFurnitureRepository FurnitureRepository
        {
            get {
                if (_furnitureRepository == null)
                    _furnitureRepository = new FurnitureRepository(_db);
                return _furnitureRepository;
            }
            
        }

        public IFurnitureCategoryRepository FurnitureCategoryRepository
        {
            get
            {
                if (_furnitureCategoryRepository == null)
                    _furnitureCategoryRepository = new FurnitureCategoryRepository(_db);
                return _furnitureCategoryRepository;
            }
        }

        public IFurnitureImagesRepository FurnitureImagesRepository {
            get
            {
                if (_furnitureImagesRepository == null)
                    _furnitureImagesRepository = new FurnitureImagesRepository(_db);
                return _furnitureImagesRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
