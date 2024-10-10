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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Ensure Identity tables are created
                                                // Define relationships
            modelBuilder.Entity<Comment>()
                .HasOne<IdentityUser>(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SkiPass>()
                .HasOne<IdentityUser>(sp => sp.User)
                .WithMany()
                .HasForeignKey(sp => sp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed IdentityUser (AspNetUser)
            var user = new IdentityUser
            {
                Id = "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3",
                UserName = "user@example.com",
                NormalizedUserName = "USER@EXAMPLE.COM",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAIAAYagAAAAEDgMpSD8PRl5bjhwpfAmC03rdAemVqABZVtyp4rm7HM1etb2110YmPLtfLQxMAzfxg==",
                SecurityStamp = "MUCKVMYLN3EZL7HJPIJBRX6GWW3TWZKS",
                ConcurrencyStamp = "3e572262-3307-4ce7-85c7-ab3aa6e9746e",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            modelBuilder.Entity<IdentityUser>().HasData(user);

            // Seed FeedPosts
            modelBuilder.Entity<FeedPost>().HasData(new FeedPost
            {
                ID = 1,
                Title = "Looking for a group to ski this weekend (Borovets)...",
                Content = "Hi I am John Doe and I am looking for a group to ski this weekend (Borovets).",
                TimeStamp = DateTime.Parse("2024-09-25 11:43:12"),
                Image = new byte[] { }, // Empty image
                ImgUrl = "",
                UserId = user.Id // Reference via foreign key
            });

            // Seed Comments (with foreign key to FeedPost and User)
            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                ID = 1,
                Content = "Anyone?",
                TimeStamp = DateTime.Parse("2024-09-25 11:44:11"),
                FeedPostID = 1, // Reference to FeedPost ID
                UserId = user.Id // Reference via foreign key
            });

            // Seed Resorts
            modelBuilder.Entity<Resort>().HasData(
                new Resort
                {
                    Id = 2,
                    Name = "Bansko",
                    AvalancheRisk = "Low avalanche risk",
                    ImageUrl = "https://my.appbuilder.dev/api/assets/750ef162-23d7-4919-9988-fd46ed1ddb8f/content?ts=2024-09-17T14:18:50.361872Z",
                    PassImageUrl = "https://my.appbuilder.dev/api/assets/d2f3a913-5acc-447d-a67d-a8fcc374421a/content?ts=2024-09-19T10:16:32.939986Z"
                },
                new Resort
                {
                    Id = 3,
                    Name = "Borovets",
                    AvalancheRisk = "Low avalanche risk",
                    ImageUrl = "https://my.appbuilder.dev/api/assets/e0c392f7-74b8-4cbd-805b-741552fe6683/content?ts=2024-09-17T14:17:57.579837Z",
                    PassImageUrl = "https://my.appbuilder.dev/api/assets/c78c2e7e-15d0-4222-8310-7656ab1fc9dc/content?ts=2024-09-19T10:18:36.851622Z"
                }
            );

            // Seed Lifts
            modelBuilder.Entity<Lift>().HasData(
                new Lift { Id = 1, Name = "Cabin lift", IsOpen = true, ResortId = 2 },
                new Lift { Id = 2, Name = "Todorka", IsOpen = true, ResortId = 2 },
                new Lift { Id = 3, Name = "Most", IsOpen = false, ResortId = 2 },
                new Lift { Id = 4, Name = "Kolarski", IsOpen = false, ResortId = 2 },
                new Lift { Id = 5, Name = "Bunderitza 1", IsOpen = true, ResortId = 2 },
                new Lift { Id = 6, Name = "Bunderitza 2", IsOpen = true, ResortId = 2 },
                new Lift { Id = 7, Name = "Gondola", IsOpen = false, ResortId = 3 },
                new Lift { Id = 8, Name = "Sitnyakovo express", IsOpen = true, ResortId = 3 }
            // Add more lifts as needed
            );

            // Seed SkiPasses
            modelBuilder.Entity<SkiPass>().HasData(
                new SkiPass
                {
                    ID = "123456",
                    UserId = user.Id,
                    IsReloadable = false,
                    IsActive = false,
                    Resort = "Bansko",
                    FirstName = "",
                    LastName = ""
                },
                new SkiPass
                {
                    ID = "pass-001",
                    UserId = user.Id,
                    IsReloadable = true,
                    IsActive = true,
                    Resort = "Bansko",
                    FirstName = "John",
                    LastName = "Doe"
                },
                new SkiPass
                {
                    ID = "pass-002",
                    UserId = user.Id,
                    IsReloadable = false,
                    IsActive = true,
                    Resort = "Borovets",
                    FirstName = "Jane",
                    LastName = "Smith"
                }
            );

            // Seed SkiPassValidationItems
            modelBuilder.Entity<SkiPassValidationItem>().HasData(
                new SkiPassValidationItem { ID = 1, Time = "9:00", Elevation = 1500, SkiPassId = "123456" },
                new SkiPassValidationItem { ID = 2, Time = "09:05", Elevation = 1500, SkiPassId = "123456" },
                new SkiPassValidationItem { ID = 3, Time = "09:10", Elevation = 1300, SkiPassId = "123456" }
            // Add more validation items as needed
            );

        }
    }
}
