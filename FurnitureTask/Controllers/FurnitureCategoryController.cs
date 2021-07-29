using BLL.FurnitureCategoryService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OutputCategory = BLL.Models.FurnitureCategory.OutputCategory;

namespace FurnitureTask.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FurnitureCategoryController : ControllerBase
    {
        private readonly IFurnitureCategoryService furnitureCategoryService;

        public FurnitureCategoryController(IFurnitureCategoryService furnitureCategoryService)
        {
            this.furnitureCategoryService = furnitureCategoryService;
        }

        [HttpGet("furniture/category")]
        public async Task<List<OutputCategory>> GetAllCategory()
        {

            return await furnitureCategoryService.GetAllCategory(); 
        }
    }
}
