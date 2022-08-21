using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
#nullable disable warnings

namespace ClearCareer.Core.ViewModels
{
    public class CreateOfferViewModel
    {
        [Required(ErrorMessage = "Title is required!")]
        [StringLength(80, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 80 characters!")]
        public string Title { get; set; }

        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Categories are required!")]
        public string Categories { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [MinLength(5, ErrorMessage = "Description must be at least 5 characters!")]
        public string Description { get; set; }

        public string? Requirements { get; set; }

        public decimal? Salary { get; set; }
    }
}
