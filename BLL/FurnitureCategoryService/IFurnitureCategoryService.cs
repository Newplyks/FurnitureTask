using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryOutModel = BLL.Models.FurnitureCategory.OutputCategory;

namespace BLL.FurnitureCategoryService
{
    public interface IFurnitureCategoryService
    {
        Task<List<CategoryOutModel>> GetAllCategory();
    }
}
