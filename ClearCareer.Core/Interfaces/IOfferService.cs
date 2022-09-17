using ClearCareer.Core.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace ClearCareer.Core.Interfaces
{
    public interface IOfferService
    {
        Task CreateOfferAsync(CreateOfferViewModel model, string ownerId, string imageName);

        Task<List<DashboardOfferViewModel>> GetAllOffersAsync();

        Task<DetailsViewModel> GetOfferByIdAsync(string offerId);

        Task<EditOfferViewModel> GetOfferForEditByIdAsync(string offerId);

        Task EditOfferAsync(EditOfferViewModel model, string imageUrl);

        Task DeleteOfferAsync(string offerId);

        Task ApplyForOfferAsync(string userId, string offerId);
    }
}
