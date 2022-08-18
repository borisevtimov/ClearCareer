using Microsoft.AspNetCore.Mvc;

namespace ClearCareer.Controllers
{
    public class OfferController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
