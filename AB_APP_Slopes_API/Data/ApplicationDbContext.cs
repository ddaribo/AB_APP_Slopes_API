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

        public string GenerateIdentityPasswordHash(string password)
        {
            var passwordHasher = new PasswordHasher<IdentityUser>();
            var hashedPassword = passwordHasher.HashPassword(new IdentityUser(), password);
            return hashedPassword;
        }

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

            modelBuilder.Entity<FeedPost>()
                .HasOne<IdentityUser>(fp => fp.User)  // A FeedPost has one User
                .WithMany()                           // A User can have many FeedPosts (no navigation in IdentityUser)
                .HasForeignKey(fp => fp.UserId)       // FeedPost uses UserId as the foreign key
                .OnDelete(DeleteBehavior.Cascade);    // Optional: Cascade delete if the User is deleted

            // FeedPost -> Resort relationship
            modelBuilder.Entity<FeedPost>()
                .HasOne<Resort>(fp => fp.Resort)      // A FeedPost has one Resort
                .WithMany()           // A Resort can have many FeedPosts
                .HasForeignKey(fp => fp.ResortId)     // FeedPost uses ResortId as the foreign key
                .OnDelete(DeleteBehavior.Cascade);    // Optional: Cascade delete if the Resort is deleted

            // Seed IdentityUser (AspNetUser)
            // pass is 123456
            var user = new IdentityUser
            {
                Id = "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3",
                UserName = "user@example.com",
                NormalizedUserName = "USER@EXAMPLE.COM",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = false,
                PasswordHash = GenerateIdentityPasswordHash("123456"),
                SecurityStamp = "MUCKVMYLN3EZL7HJPIJBRX6GWW3TWZKS",
                ConcurrencyStamp = "3e572262-3307-4ce7-85c7-ab3aa6e9746e",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            modelBuilder.Entity<IdentityUser>().HasData(user);

            List<Resort> resorts = new List<Resort>() { new Resort
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
                },
                  new Resort
                  {
                      Id = 4,
                      Name = "Vitosha",
                      AvalancheRisk = "Low avalanche risk",
                      ImageUrl = "https://my.appbuilder.dev/api/assets/8651aee7-d411-47dd-90d7-615290048064/content?ts=2024-10-10T10:33:00.6130576Z",
                      PassImageUrl = "https://my.appbuilder.dev/api/assets/8d47d314-622d-405f-8d3b-59d5b6d71bbd/content?ts=2024-10-10T10:33:01.1651277Z"
                  }
            };
            // Seed Resorts
            modelBuilder.Entity<Resort>().HasData(
              resorts
            );

            // Seed FeedPosts
            FeedPost fp1 = new FeedPost
            {
                ID = 1,
                Title = "Looking for Skiing Buddies in Bansko",
                Content = "Hey all, I'm heading to Bansko next weekend and looking for some people to hit the slopes with. Anyone else going to be there?",
                TimeStamp = DateTime.Now.AddDays(-1),
                ImgUrl = "https://i.pinimg.com/enabled/564x/36/be/12/36be1290508048c9fdd3bf1511ffa592.jpg",
                UserId = user.Id,
                ResortId = resorts[0].Id,
                //User = user,
                //Resort = resorts[0]
            };

            FeedPost fp2 = new FeedPost
            {
                ID = 2,
                Title = "Snow Report Update",
                Content = "Just got word that it's dumping snow in Boro! Powder forecasted for the weekend. Anyone else stoked to ride?",
                TimeStamp = DateTime.Now.AddDays(-2),
                ImgUrl = "https://i.pinimg.com/564x/c8/6c/7c/c86c7c63b7f55e360bfa4491c4e3dd26.jpg",
                UserId = user.Id,
                ResortId = resorts[1].Id,
                //User = user,
                //Resort = resorts[1]
            };

            FeedPost fp3 = new FeedPost
            {
                ID = 3,
                Title = "Ski Gear Recommendations?",
                Content = "Looking to upgrade my ski boots before the season kicks off. Any recommendations for comfortable, high-performance gear?",
                TimeStamp = DateTime.Now.AddDays(-3),
                ImgUrl = "https://i.pinimg.com/enabled/564x/1a/89/2c/1a892c25e8b9c2b589b12133fd24e300.jpg",
                UserId = user.Id,
                ResortId = resorts[2].Id,
                //User = user,
                //Resort = resorts[2]
            };

            FeedPost fp4 = new FeedPost
            {
                ID = 4,
                Title = "Best Après-Ski Spots in Bansko?",
                Content = "First time in Bansko this December. Any tips on the best après-ski bars or events? I'd love to meet other skiers after the runs.",
                TimeStamp = DateTime.Now.AddDays(-4),
                ImgUrl = "https://i.pinimg.com/enabled/564x/65/69/2a/65692a30d16e3817cd5d05608f0a41a0.jpg",
                UserId = user.Id,
                ResortId = resorts[0].Id,
                //User = user,
                //Resort = resorts[0]
            };

            FeedPost fp5 = new FeedPost
            {
                ID = 5,
                Title = "Group Ski Trip to the Bansko",
                Content = "Planning a group trip to Bansko in January. Anyone interested in joining? We're booking a chalet and have a few spots open.",
                TimeStamp = DateTime.Now.AddDays(-5),
                ImgUrl = "https://i.pinimg.com/enabled/564x/2b/95/39/2b9539d0addcff3c3def40510f1a3ea5.jpg",
                UserId = user.Id,
                ResortId = resorts[0].Id,
                //User = user,
                //Resort = resorts[0]
            };
            List<FeedPost> posts = new List<FeedPost>() { fp1, fp2, fp3, fp4, fp5 };
            modelBuilder.Entity<FeedPost>().HasData(posts);
            

            // Seed Comments (with foreign key to FeedPost and User)
            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                ID = 1,
                Content = "Anyone?",
                TimeStamp = DateTime.Parse("2024-09-25 11:44:11"),
                FeedPostID = 1, // Reference to FeedPost ID
                UserId = user.Id // Reference via foreign key
            });

            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                ID = 2,
                Content = "I have a great recommendation for ski boots! Check out the new Salomon X Pro series.",
                TimeStamp = DateTime.Parse("2024-09-24 14:30:00"),
                FeedPostID = 3, // This refers to the third FeedPost: "Ski Gear Recommendations?"
                UserId = user.Id // The same user who posted the feed
            });

            // Seed Lifts
            modelBuilder.Entity<Lift>().HasData(
                new Lift { Id = 1, Name = "Cabin lift", IsOpen = true, ResortId = 2 },
                new Lift { Id = 2, Name = "Todorka", IsOpen = true, ResortId = 2 },
                new Lift { Id = 3, Name = "Most", IsOpen = false, ResortId = 2 },
                new Lift { Id = 4, Name = "Kolarski", IsOpen = false, ResortId = 2 },
                new Lift { Id = 5, Name = "Bunderitza 1", IsOpen = true, ResortId = 2 },
                new Lift { Id = 6, Name = "Bunderitza 2", IsOpen = true, ResortId = 2 },
                new Lift { Id = 7, Name = "Gondola", IsOpen = false, ResortId = 3 },
                new Lift { Id = 8, Name = "Sitnyakovo express", IsOpen = true, ResortId = 3 },
                new Lift { Id = 9, Name = "Martinovi baraki", IsOpen = true, ResortId = 3 },
                new Lift { Id = 10, Name = "Yastrebetz Express", IsOpen = true, ResortId = 3 },
                new Lift { Id = 11, Name = "Markudzhik", IsOpen = true, ResortId = 3 },
                new Lift { Id = 12, Name = "Cabin lift", IsOpen = true, ResortId = 4 },
                new Lift { Id = 13, Name = "Lale 1", IsOpen = true, ResortId = 4 },
                new Lift { Id = 14, Name = "Lale 2", IsOpen = true, ResortId = 4 },
                new Lift { Id = 15, Name = "Pomagalski", IsOpen = true, ResortId = 4 },
                new Lift { Id = 16, Name = "Mecha polyana", IsOpen = true, ResortId = 4 }
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
                    ResortId = 2,
                    FirstName = "",
                    LastName = ""
                },
                new SkiPass
                {
                    ID = "pass-001",
                    UserId = user.Id,
                    IsReloadable = true,
                    IsActive = true,
                    ResortId = 2,
                    FirstName = "John",
                    LastName = "Doe"
                },
                new SkiPass
                {
                    ID = "pass-002",
                    UserId = user.Id,
                    IsReloadable = false,
                    IsActive = true,
                    ResortId = 3,
                    FirstName = "Jane",
                    LastName = "Smith"
                }
            );

            List<SkiPassValidationItem> skiPassData = new List<SkiPassValidationItem>
        {
            new SkiPassValidationItem { ID = 1, Time = "09:00", Elevation = 1500, SkiPassId = "123456", LiftId = 1 },
            new SkiPassValidationItem { ID = 2, Time = "09:35", Elevation = 2300, SkiPassId = "123456", LiftId = 1 },
            new SkiPassValidationItem { ID = 3, Time = "09:40", Elevation = 1700, SkiPassId = "123456", LiftId = 3 },
            new SkiPassValidationItem { ID = 4, Time = "09:45", Elevation = 1900, SkiPassId = "123456", LiftId = 3 },
            new SkiPassValidationItem { ID = 5, Time = "09:55", Elevation = 1200, SkiPassId = "123456", LiftId = 4 },
            new SkiPassValidationItem { ID = 6, Time = "10:05", Elevation = 1750, SkiPassId = "123456", LiftId = 4 },
            new SkiPassValidationItem { ID = 7, Time = "10:06", Elevation = 1300, SkiPassId = "123456", LiftId = 5 },
            new SkiPassValidationItem { ID = 8, Time = "10:14", Elevation = 1800, SkiPassId = "123456", LiftId = 5 },
            new SkiPassValidationItem { ID = 9, Time = "10:20", Elevation = 1800, SkiPassId = "123456", LiftId = 6 },
            new SkiPassValidationItem { ID = 10, Time = "10:35", Elevation = 2500, SkiPassId = "123456", LiftId = 6 },
            new SkiPassValidationItem { ID = 11, Time = "11:00", Elevation = 1500, SkiPassId = "123456", LiftId = 1 },
            new SkiPassValidationItem { ID = 12, Time = "11:35", Elevation = 1900, SkiPassId = "123456", LiftId = 1 },
            new SkiPassValidationItem { ID = 13, Time = "11:40", Elevation = 1200, SkiPassId = "123456", LiftId = 4 },
            new SkiPassValidationItem { ID = 14, Time = "11:49", Elevation = 1750, SkiPassId = "123456", LiftId = 4 },

            new SkiPassValidationItem { ID = 49, Time = "08:30", Elevation = 1500, SkiPassId = "pass-001", LiftId = 9 },
            new SkiPassValidationItem { ID = 50, Time = "09:15", Elevation = 1600, SkiPassId = "pass-001", LiftId = 9 }
        };
        modelBuilder.Entity<SkiPassValidationItem>().HasData(skiPassData);
        }
    }
}
