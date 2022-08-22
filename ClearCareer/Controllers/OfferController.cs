using ClearCareer.Core.Interfaces;
using ClearCareer.Core.ViewModels;
using ClearCareer.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
#nullable disable warnings

namespace ClearCareer.Controllers
{
    public class OfferController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IOfferService offerService;
        private readonly UserManager<ApplicationUser> userManager;

        public OfferController(IWebHostEnvironment webHostEnvironment,
            IOfferService offerService,
            UserManager<ApplicationUser> userManager)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.offerService = offerService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            List<DashboardOfferViewModel> offers = await offerService.GetAllOffersAsync();

            return View(offers);
        }

        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create(CreateOfferViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Model is not valid!");
                }

                ApplicationUser user = await userManager.GetUserAsync(User);
                string imageName = await DownloadImageAsync(model.Image);
                await offerService.CreateOfferAsync(model, user.Id, imageName);

            }
            catch (Exception)
            {
                return View();
            }

            return Redirect("/Offer/All");
        }

        public async Task<IActionResult> Details(string Id)
        {
            DetailsViewModel detailsModel = await offerService.GetOfferByIdAsync(Id);

            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = await userManager.GetUserAsync(User);
                detailsModel.UserId = user.Id;
            }

            return View(detailsModel);
        }

        private async Task<string> DownloadImageAsync(IFormFile image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using FileStream fileStream = new(filePath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }
    }
}
