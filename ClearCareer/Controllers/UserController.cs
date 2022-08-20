using ClearCareer.Core.Interfaces;
using ClearCareer.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                await userService.LoginUserAsync(model);
            }
            catch (Exception)
            {
                return View();
            }

            return Redirect("/Offer/All");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                (bool isValid, string errorMessage) = await userService.UserExistsAsync(model);

                if (!isValid)
                {
                    return View();
                }

                await userService.RegisterUserAsync(model);
            }
            catch (Exception)
            {
                return View();
            }

            return Redirect("/Offer/All");
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Logout()
        {
            await userService.SignOutAsync();

            return Redirect("/");
        }
    }
}