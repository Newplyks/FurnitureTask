using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IFurnitureRepository FurnitureRepository { get; }
        IFurnitureCategoryRepository FurnitureCategoryRepository { get; }
        IFurnitureImagesRepository FurnitureImagesRepository {  get; }
        Task CommitAsync();
    }
}
