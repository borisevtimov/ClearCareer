using ClearCareer.Core.Interfaces;
using ClearCareer.Core.Utilities;
using ClearCareer.Core.ViewModels;
using ClearCareer.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
#nullable disable warnings

namespace ClearCareer.Controllers
{
    public class OfferController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IOfferService offerService;
        private readonly IPictureProcessor pictureProcessor;
        private readonly UserManager<ApplicationUser> userManager;

        public OfferController(IWebHostEnvironment webHostEnvironment,
            IOfferService offerService,
            IPictureProcessor pictureProcessor,
            UserManager<ApplicationUser> userManager)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.offerService = offerService;
            this.pictureProcessor = pictureProcessor;
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

                string imageName = await pictureProcessor
                    .DownloadImageAsync($"{webHostEnvironment.WebRootPath}/images", model.Image);

                await offerService.CreateOfferAsync(model, user.Id, imageName);

            }
            catch (Exception)
            {
                return View();
            }

            return Redirect("/Offer/All");
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Delete(string id)
        {
            await offerService.DeleteOfferAsync(id);
            await pictureProcessor.DeleteUnusedPicturesAsync($"{webHostEnvironment.WebRootPath}/images");
            return Redirect("/Offer/All");
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Edit(string id)
        {
            EditOfferViewModel model = await offerService.GetOfferForEditByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Edit(EditOfferViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Invalid model!");
                }

                string imageName = await pictureProcessor
                    .DownloadImageAsync($"{webHostEnvironment.WebRootPath}/images", model.Image);
                await offerService.EditOfferAsync(model, imageName);
                await pictureProcessor.DeleteUnusedPicturesAsync($"{webHostEnvironment.WebRootPath}/images");
                return Redirect($"/Offer/Details/{model.Id}");
            }
            catch (Exception)
            {
                return View();
            }
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

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Apply(string id)
        {
            try
            {
                ApplicationUser user = await userManager.GetUserAsync(User);
                await offerService.ApplyForOfferAsync(user.Id, id);
                return Redirect($"/Offer/Details/{id}");
            }
            catch (InvalidOperationException)
            {
                return Redirect($"/Offer/Details/{id}");
            }
            catch (Exception)
            {
                return Redirect($"/Offer/Details/{id}");
            }
        }
    }
}
