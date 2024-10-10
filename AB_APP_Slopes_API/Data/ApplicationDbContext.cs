using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AB_APP_Slopes_API.Models;

namespace AB_APP_Slopes_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Resort> Resorts { get; set; }  
        public DbSet<Lift> Lifts { get; set; }  
        public DbSet<SkiPass> SkiPasses { get; set; }  
        public DbSet<SkiPassValidationItem> SkiPassValidationItems { get; set; }  
        public DbSet<FeedPost> SocialFeed { get; set; }  
        public DbSet<Comment> Comments { get; set; }  
    }
}
