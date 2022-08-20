using System.ComponentModel.DataAnnotations;
#nullable disable warnings

namespace ClearCareer.Core.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UsernameOrEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
