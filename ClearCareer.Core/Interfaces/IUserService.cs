using ClearCareer.Core.ViewModels;

namespace ClearCareer.Core.Interfaces
{
    public interface IUserService
    {
        Task<Tuple<bool, string>> UserExistsAsync(RegisterViewModel model);

        Task RegisterUserAsync(RegisterViewModel model);
    }
}