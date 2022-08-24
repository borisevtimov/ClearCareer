using System.ComponentModel.DataAnnotations;
using ClearCareer.Core.Constants;
#nullable disable warnings

namespace ClearCareer.Core.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = UsersConstant.Login.RequiredUsernameOrEmail)]
        public string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = UsersConstant.Login.RequiredPassword)]
        public string Password { get; set; }
    }
}
