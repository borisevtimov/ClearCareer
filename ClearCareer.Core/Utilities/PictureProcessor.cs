using ClearCareer.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
#nullable disable warnings

namespace ClearCareer.Core.Utilities
{
    public class PictureProcessor : IPictureProcessor
    {
        private readonly ApplicationDbContext dbContext;

        public PictureProcessor(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task DeleteUnusedPicturesAsync(string imagesFolder)
        {
            string[] images = Directory.GetFiles(imagesFolder);
            List<string?> offersImages = await dbContext.Offers.Select(offer => offer.ImageUrl).ToListAsync();

            foreach (string image in images)
            {
                if (!offersImages.Contains(Path.GetFileName(image)))
                {
                    File.Delete(image);
                }
            }
        }

        public async Task<string> DownloadImageAsync(string imagesFolder, IFormFile image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                uniqueFileName = Guid.NewGuid().ToString()
                    .Replace('/', 'a').Replace('\\', 'b') + "==_" + image.FileName;
                string filePath = Path.Combine(imagesFolder, uniqueFileName);

                using FileStream fileStream = new(filePath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }
    }
}
