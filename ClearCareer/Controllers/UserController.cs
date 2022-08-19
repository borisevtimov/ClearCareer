using ClearCareer.Core.Interfaces;
using ClearCareer.Core.Services;
using ClearCareer.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClearCareer.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {

            }

            (bool isValid, string errorMessage) = await userService.UserExistsAsync(model);

            if (!isValid)
            {

            }

            try
            {
                await userService.RegisterUserAsync(model);
            }
            catch (Exception)
            {
                throw;
            }

            return Redirect("/Offer/All");
        }

        public IActionResult Logout()
        {
            SignOut();
            return Redirect("/");
        }
    }
}