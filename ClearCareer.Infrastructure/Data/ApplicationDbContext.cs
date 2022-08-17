using ClearCareer.Infrastructure.Data.Models;
using ClearCareer.Infrastructure.Data.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClearCareer.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            ModelCreator.RenameEntities(builder);
            ModelCreator.IgnoreUnusedColumns(builder);
        }
    }
}