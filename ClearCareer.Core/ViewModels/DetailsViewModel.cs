#nullable disable warnings

namespace ClearCareer.Core.ViewModels
{
    public class DetailsViewModel
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Categories { get; set; }

        public decimal? Salary { get; set; }

        public string Description { get; set; }

        public string? Requirements { get; set; }

        public string OwnerId { get; set; }

        public string UserId { get; set; }

        public int ApplicationsCount { get; set; }
    }
}