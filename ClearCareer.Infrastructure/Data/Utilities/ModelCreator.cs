using ClearCareer.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClearCareer.Infrastructure.Data.Utilities
{
    public static class ModelCreator
    {
        public static void RenameEntities(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            builder.Entity<ApplicationUser>().Property(p => p.UserName).HasColumnName("Username");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
    }
}
