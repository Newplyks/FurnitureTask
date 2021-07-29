using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FurnitureImagesOutModel = BLL.Models.FurnitureImages.OutputModel;

namespace BLL.FurnitureImagesService
{
    public interface IFurnitureImageService
    {
        void DeleteFurnitureImage(string imagePath);
        Task SaveFurnitureImage(Guid furnitureId, Guid categoryId, Guid imageId, byte[] image);
        Task<FurnitureImagesOutModel> GetFurnitureImages(string[] pathImages);
    }
}
