using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FurnitureInputModel = BLL.Models.Furniture.InputModel;
using FurnitureOutModel = BLL.Models.Furniture.OutputModel;
using FurnitureOutCollectionModel = BLL.Models.Furniture.CollectionOutputModel;

namespace BLL.FurnitureServices
{
    public interface IFurnitureService
    {
        Task Delete(Guid id);
        Task<Guid> Create(FurnitureInputModel inputModel);
        Task<FurnitureOutModel> Get(Guid Id);
        Task Update(FurnitureInputModel inputModel, Guid Id);
        Task<FurnitureOutCollectionModel> GetAll(int size, int lastIndex);

    }
}
