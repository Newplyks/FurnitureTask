using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FurnitureImagesOutModel = BLL.Models.FurnitureImages.OutputModel;

namespace BLL.FurnitureImagesService
{
    public class FurnitureImageService : IFurnitureImageService
    {
        public FurnitureImageService()
        {
        }

        public void DeleteFurnitureImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
            var pathDirWithImages = Directory.GetParent(imagePath).FullName;
            if (Directory.GetFiles(pathDirWithImages).Length == 0)
            {
                Directory.Delete(pathDirWithImages);
            }
        }

        public async Task<FurnitureImagesOutModel> GetFurnitureImages(string[] pathImages)
        {
            FurnitureImagesOutModel result = new FurnitureImagesOutModel();
            foreach(var file in pathImages)
            {
                if (File.Exists(file))
                {
                    var image = await System.IO.File.ReadAllBytesAsync(file);
                    result.Images.Add(Guid.Parse(file.Split('/').Last()), image);
                }
            }
            return result;  
            
        }

        public async Task SaveFurnitureImage(Guid furnitureId, Guid categoryId, Guid imageId, byte[] image)
{
            //string path = $"/Files/{categoryId}/{furnitureId}/{imageId}";
            string pathDirWithImages = $"{categoryId}/{furnitureId}";
            if (!Directory.Exists(pathDirWithImages))
            {
                Directory.CreateDirectory(pathDirWithImages);
            }
            await File.WriteAllBytesAsync($"{pathDirWithImages}/{imageId}", image);
        }
    }
}
