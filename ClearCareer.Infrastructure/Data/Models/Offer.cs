using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable warnings

namespace ClearCareer.Infrastructure.Data.Models
{
    public class Offer
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        public string? ImageUrl { get; set; }

        public string Categories { get; set; }

        public string Description { get; set; }

        public string? Requirements { get; set; }

        public decimal? Salary { get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        [Required]
        public ApplicationUser Owner { get; set; }
    }
}
