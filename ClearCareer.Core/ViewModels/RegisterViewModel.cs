using System.ComponentModel.DataAnnotations;
using ClearCareer.Core.Constants;
#nullable disable warnings

namespace ClearCareer.Core.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = UsersConstant.Register.Username.Required)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = UsersConstant.Register.Username.Length)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = UsersConstant.Register.Email.Required)]
        [EmailAddress(ErrorMessage = UsersConstant.Register.Email.Invalid)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = UsersConstant.Register.Password.Required)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = UsersConstant.Register.Password.Length)]
        public string Password { get; set; }

        [Required(ErrorMessage = UsersConstant.Register.ConfirmPassword.Required)]
        [Compare(nameof(Password), ErrorMessage = UsersConstant.Register.ConfirmPassword.NotMatch)]

        public string ConfirmPassword { get; set; }
    }
}
