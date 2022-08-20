using ClearCareer.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClearCareer.Controllers
{
    public class OfferController : Controller
    {
        public IActionResult All()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateOfferViewModel model)
        {
            return View();
        }
    }
}
