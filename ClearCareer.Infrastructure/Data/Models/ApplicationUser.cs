using Microsoft.AspNetCore.Identity;

namespace ClearCareer.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
    }
}
