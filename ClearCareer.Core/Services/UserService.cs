using ClearCareer.Core.Interfaces;
using ClearCareer.Core.ViewModels;
using ClearCareer.Infrastructure.Data;
using ClearCareer.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
#nullable disable warnings

namespace ClearCareer.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserService(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task RegisterUserAsync(RegisterViewModel model)
        {
            ApplicationUser user = new()
            {
                UserName = model.Username,
                Email = model.Email,
                PasswordHash = HashPassword(model.Password)
            };

            IdentityResult result = await userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception("Error creating a user!");
            }

            if (!await userManager.IsInRoleAsync(user, "User"))
            {
                await userManager.AddToRoleAsync(user, "User");
            }

            await signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task LoginUserAsync(LoginViewModel model)
        {
            ApplicationUser user = await context.ApplicationUsers
                .FirstOrDefaultAsync(u => (u.UserName == model.UsernameOrEmail || u.Email == model.UsernameOrEmail)
                && u.PasswordHash == HashPassword(model.Password));

            if (user == null)
            {
                throw new ArgumentException("Invalid login credentials!");
            }

            await signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<Tuple<bool, string>> UserExistsAsync(RegisterViewModel model)
        {
            bool isValid = true;
            string errorMessage = null;

            ApplicationUser? user = await context.ApplicationUsers
                .FirstOrDefaultAsync(u => u.UserName == model.Username || u.Email == model.Email);

            if (user != null)
            {
                errorMessage = user.Email == model.Email ? "Email already exists!" : "Username already exists!";
                isValid = false;
            }

            return new Tuple<bool, string>(isValid, errorMessage);
        }

        private static string HashPassword(string password)
        {
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);

            using SHA256 hash = SHA256.Create();
            return Convert.ToBase64String(hash.ComputeHash(bytePassword));
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
