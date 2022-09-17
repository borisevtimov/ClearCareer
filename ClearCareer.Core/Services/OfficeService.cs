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

        public async Task ApplyForOfferAsync(string userId, string offerId)
        {
            Application application = await context.Applications
                .FirstOrDefaultAsync(a => a.UserId == userId && a.OfferId == offerId);

            if (application != null)
            {
                throw new InvalidOperationException("Application already exists!");
            }

            Application newApplication = new()
            {
                UserId = userId,
                OfferId = offerId
            };

            await context.Applications.AddAsync(newApplication);
            await context.SaveChangesAsync();
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

        public async Task DeleteOfferAsync(string offerId)
        {
            Offer offer = await context.Offers.FirstOrDefaultAsync(offer => offer.Id == offerId);

            context.Offers.Remove(offer);
            await context.SaveChangesAsync();
        }

        public async Task EditOfferAsync(EditOfferViewModel model, string imageUrl)
        {
            Offer? offer = await context.Offers.FirstOrDefaultAsync(offer => offer.Id == model.Id);

            offer.Requirements = model.Requirements;
            offer.Title = model.Title;
            offer.Categories = model.Categories;
            offer.Description = model.Description;
            offer.ImageUrl = imageUrl ?? OffersConstant.Image.DefaultImageName;
            offer.Salary = model.Salary;

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
                    Title = offer.Title,
                    ApplicationsCount = GetApplicationCount(offerId)
                })
                .FirstOrDefaultAsync(offer => offer.Id == offerId);
        }

        private int GetApplicationCount(string offerId)
        {
            return context.Applications.Count(a => a.OfferId == offerId);
        }

        public async Task<EditOfferViewModel> GetOfferForEditByIdAsync(string offerId)
        {
            return await context.Offers
                .Select(offer => new EditOfferViewModel()
                {
                    Id = offer.Id,
                    Categories = offer.Categories,
                    Description = offer.Description,
                    Requirements = offer.Requirements,
                    Salary = offer.Salary,
                    Title = offer.Title
                })
                .FirstOrDefaultAsync(offer => offer.Id == offerId);
        }
    }
}