using BLL.Models.FurnitureCategory;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryCollectionItemOutModel = BLL.Models.FurnitureCategory.OutputCategory;

namespace BLL.FurnitureCategoryService
{
    public class FurnitureCategoryService : IFurnitureCategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public FurnitureCategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryCollectionItemOutModel>> GetAllCategory()
        {
            var categories = await unitOfWork.FurnitureCategoryRepository.GetAll();
            var result = categories.Select(x => new CategoryCollectionItemOutModel() { Id = x.Id, Title = x.Title}).ToList();
            return result;

        }
    }
}
