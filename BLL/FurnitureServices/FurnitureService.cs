using BLL.FurnitureImagesService;
using BLL.Models.Furniture;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FurnitureInputModel = BLL.Models.Furniture.InputModel;
using FurnitureOutModel = BLL.Models.Furniture.OutputModel;
using FurnitureOutCollectionModel = BLL.Models.Furniture.CollectionOutputModel;
using Common.Exceptions;

namespace BLL.FurnitureServices
{
    public class FurnitureService : IFurnitureService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFurnitureImageService imageService;

        public FurnitureService(IUnitOfWork unitOfWork, IFurnitureImageService imageService)
        {
            this.unitOfWork = unitOfWork;
            this.imageService = imageService;
        }

        public async Task<Guid> Create(FurnitureInputModel inputModel)
        {
            FurnitureCategory category = await unitOfWork.FurnitureCategoryRepository.GetAsync(inputModel.CategoryId);
            if(category == null)
            {
                throw new FurnitureValidationException("This category doen't exist");
            }
            validateFurniture(inputModel);
            Furniture newFurniture = new Furniture();
            newFurniture.Title = inputModel.Title;
            newFurniture.Description = inputModel.Description;
            newFurniture.Category = category;
            newFurniture.Id = Guid.NewGuid();
            await unitOfWork.FurnitureRepository.CreateAsync(newFurniture);
            await unitOfWork.CommitAsync();
            return newFurniture.Id;

        }

        public async Task Delete(Guid id)
        {
            var item = await unitOfWork.FurnitureRepository.GetAsync(id);
            if(item == null)
            {
                throw new FurnitureNotFoundException("Furniture not found");
            }
            else
            {
                await unitOfWork.FurnitureRepository.DeleteAsync(item);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task<FurnitureOutModel> Get(Guid id)
        {
            var result = await unitOfWork.FurnitureRepository.GetAsync(id);
            if(result == null)
            {
                throw new FurnitureNotFoundException("Furniture not found");
            }
            return new FurnitureOutModel() { Id = result.Id, Title = result.Title, Description = result.Description, CategoryId = result.CategoryId, CreatedTime = result.CreatedDate };
        }

        public async Task<CollectionOutputModel> GetAll(int size, int skip)
        {
            CollectionOutputModel result = new CollectionOutputModel() {
                Total = await unitOfWork.FurnitureRepository.GetCountFurniture(),
                Size = size,
                Skip = skip
            };
            var furniture = await unitOfWork.FurnitureRepository.GetAll(skip, size);
            result.Furniture = furniture.Select(x => new FurnitureOutModel() {Id = x.Id ,Title = x.Title, Description = x.Description, CategoryId = x.CategoryId });
            return result; 
        }

        public async Task Update(FurnitureInputModel inputModel, Guid Id)
        {
            var item = await unitOfWork.FurnitureRepository.GetAsync(Id);
            if(item == null)
            {
                throw new FurnitureNotFoundException("Furniture not found");
            }
            item.Title = inputModel.Title;
            item.Description = inputModel.Description;
            item.CategoryId = inputModel.CategoryId;
            await unitOfWork.FurnitureRepository.UpdateAsync(item);
            await unitOfWork.CommitAsync();
        }

        private void validateFurniture(FurnitureInputModel model) {
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new FurnitureValidationException("Field \'Title\' is empty");
            }
            if(model.Title.Length < 3 || model.Title.Length > 256)
            {
                throw new FurnitureValidationException("Length of field \'Title\' must be graiter 3 and less 256 symbols");
            }
            if(model.Description == null)
            {
                model.Description = string.Empty;
            } 
        }
    }
}
