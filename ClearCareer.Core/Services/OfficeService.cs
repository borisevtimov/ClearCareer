using ClearCareer.Core.Constants;
using ClearCareer.Core.Interfaces;
using ClearCareer.Core.ViewModels;
using ClearCareer.Infrastructure.Data;
using ClearCareer.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
#nullable disable warnings

namespace ClearCareer.Core.Services
{
    public class OfficeService : IOfferService
    {
        private readonly ApplicationDbContext context;

        public OfficeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateOfferAsync(CreateOfferViewModel model, string ownerId, string imageName)
        {
            Offer offer = new()
            {
                Title = model.Title,
                ImageUrl = imageName ?? OffersConstant.Image.DefaultImageName,
                Description = model.Description,
                Categories = model.Categories,
                Requirements = model.Requirements,
                Salary = model.Salary,
                OwnerId = ownerId
            };

            await context.Offers.AddAsync(offer);
            await context.SaveChangesAsync();
        }

        public async Task<List<DashboardOfferViewModel>> GetAllOffersAsync()
        {
            return await context.Offers
                .Select(offer => new DashboardOfferViewModel()
                {
                    Id = offer.Id,
                    ImageUrl = offer.ImageUrl,
                    Salary = offer.Salary,
                    Title = offer.Title
                })
                .OrderByDescending(o => o.Salary.HasValue)
                .ToListAsync();
        }

        public async Task<DetailsViewModel> GetOfferByIdAsync(string offerId)
        {
            return await context.Offers
                .Select(offer => new DetailsViewModel()
                {
                    Id = offer.Id,
                    OwnerId = offer.OwnerId,
                    Categories = offer.Categories,
                    Description = offer.Description,
                    ImageUrl = offer.ImageUrl,
                    Requirements = offer.Requirements,
                    Salary = offer.Salary,
                    Title = offer.Title
                })
                .FirstOrDefaultAsync(offer => offer.Id == offerId);
        }
    }
}
