using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable warnings

namespace ClearCareer.Infrastructure.Data.Models
{
    public class Application
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(ApplicationUser))]
        public string? UserId { get; set; }

        [ForeignKey(nameof(Offer))]
        public string? OfferId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        public Offer? Offer { get; set; }
    }
}
