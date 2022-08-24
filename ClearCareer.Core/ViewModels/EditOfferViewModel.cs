using ClearCareer.Core.Constants;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
#nullable disable warnings

namespace ClearCareer.Core.ViewModels
{
    public class EditOfferViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = OffersConstant.Title.Required)]
        [StringLength(80, MinimumLength = 1, ErrorMessage = OffersConstant.Title.Length)]
        public string Title { get; set; }

        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = OffersConstant.Categories.Required)]
        public string Categories { get; set; }

        [Required(ErrorMessage = OffersConstant.Description.Required)]
        [MinLength(5, ErrorMessage = OffersConstant.Description.MinLength)]
        public string Description { get; set; }

        public string? Requirements { get; set; }

        public decimal? Salary { get; set; }
    }
}