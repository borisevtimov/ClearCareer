using System.ComponentModel.DataAnnotations;
#nullable disable warnings

namespace ClearCareer.Core.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 20 characters!")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Enter valid email address!")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required!")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
