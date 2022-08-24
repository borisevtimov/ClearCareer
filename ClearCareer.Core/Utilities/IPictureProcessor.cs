using Microsoft.AspNetCore.Http;

namespace ClearCareer.Core.Utilities
{
    public interface IPictureProcessor
    {
        Task DeleteUnusedPicturesAsync(string imagesPath);

        Task<string> DownloadImageAsync(string imagesFolder, IFormFile image);
    }
}
