using ClearCareer.Core.ViewModels;

namespace ClearCareer.Core.Interfaces
{
    public interface IOfferService
    {
        Task CreateOfferAsync(CreateOfferViewModel model, string ownerId, string imageName);

        Task<List<DashboardOfferViewModel>> GetAllOffersAsync();
    }
}
