using BLL.FurnitureServices;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FurnitureInputModel = BLL.Models.Furniture.InputModel;
using FurnitureOutModel = BLL.Models.Furniture.OutputModel;
using FurnitureOutCollectionModel = BLL.Models.Furniture.CollectionOutputModel;
using BLL.FurnitureImagesService;

namespace FurnitureTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {
        private readonly IFurnitureService furnitureService;

        public FurnitureController(IFurnitureService furnitureService)
        {
            this.furnitureService = furnitureService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FurnitureOutModel>> GetFurniture(Guid id)
        {
            var result = await furnitureService.Get(id);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFurniture(Guid id)
        {
            await furnitureService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> CreateFurniture(Guid id, [FromBody] FurnitureInputModel inputModel )
        {
            await furnitureService.Update(inputModel, id);
            return NoContent();
        }

        [HttpPost()]
        public async Task<ActionResult> UpdateFurniture([FromBody] FurnitureInputModel inputModel)
        {
            var result = await furnitureService.Create(inputModel);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<FurnitureOutModel>> GetFurniture([FromQuery] int size, [FromQuery] int skip)
        {
            if(size <= 0)
            {
                throw new ArgumentException("Parameter \'size\' must be greiter 0");
            }
            if (skip < 0)
            {
                throw new ArgumentException("Parameter \'skip\' must be 0 or greiter");
            }
            var result = await furnitureService.GetAll(size, skip);
            return Ok(result);
        }
    }
}
