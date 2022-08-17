using Microsoft.AspNetCore.Mvc;

namespace ClearCareer.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            SignOut();
            return Redirect("/");
        }
    }
}