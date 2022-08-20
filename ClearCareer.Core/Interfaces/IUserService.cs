using ClearCareer.Core.ViewModels;
using Microsoft.AspNetCore.Http;

namespace ClearCareer.Core.Interfaces
{
    public interface IUserService
    {
        Task<Tuple<bool, string>> UserExistsAsync(RegisterViewModel model);

        Task RegisterUserAsync(RegisterViewModel model);

        Task LoginUserAsync(LoginViewModel model);

        Task SignOutAsync();
    }
}