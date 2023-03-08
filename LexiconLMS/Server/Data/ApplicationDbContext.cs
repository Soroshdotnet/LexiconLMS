using Duende.IdentityServer.EntityFramework.Options;
using LexiconLMS.Server.Models;
using LexiconLMS.Shared;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace LexiconLMS.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
    DbContextOptions options,
    IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Activity> Activities => Set<Activity>();
        public DbSet<ActivityType> ActivityTypes => Set<ActivityType>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<Module> Modules => Set<Module>();
        //public DbSet<User> User => Set<User>();

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            //modelBuilder.Seed();


//            modelBuilder.Entity<Activity>().HasData(
//                 new Activity { Id = -11,/*ID = -1, Desc = "abc", ActivityTypeID = -1, Module_id = -1, */Name = "ABC" },
//                   new Activity { Id = -12,/*ID = -2, Desc = "def", ActivityTypeID = -2, Module_id = -2, */Name = "DEF" },
//                   new Activity { Id = -13,/*ID = -3, Desc = "ghi", ActivityTypeID = -3, Module_id = -3,*/ Name = "GHI" },
//                   new Activity { Id = -14,/*ID = -4, Desc = "jkl", ActivityTypeID = -4, Module_id = -4, */Name = "JKL" }
//                );

//            modelBuilder.Entity<ActivityType>().HasData(
//     new ActivityType { ID = -1, Type = "Lesson" },
//       new ActivityType { ID = -2, Type = "Test" }
//    );

//            modelBuilder.Entity<ApplicationUser>().HasData(
//new ApplicationUser { Id = "-1", UserName = "abc", Email = "abc@hotmail.com"
///*, Name = "ABC", *//*Password = "abc", *//*Course_id = -1*/},
//new ApplicationUser { Id = "-2", UserName = "def", Email = "def@hotmail.com"
////,
//    //Name = "DEF",
//    //Password = "def",
//    //Course_id = -2
//}
//);

//            modelBuilder.Entity<Course>().HasData(
//new Course { Id = -12,/*ID = -1, */Desc = "-1", Name = "Programming .NET" },
//new Course { Id = -13,/*ID = -2, */Desc = "-2", Name = "Programming Frontend" }
//);

//            modelBuilder.Entity<Document>().HasData(
//new Document { Id = -10/* ID = -1, Module_id = -1, Lesson_id = -1, Course_id = -1, Name = "E-learning"*/ },
//new Document { Id = -11/*ID = -2, Module_id = -1, Lesson_id = -1, Course_id = -1, Name = "Slideshow"*/ }
//);

//            modelBuilder.Entity<Module>().HasData(
//new Module
//{
//    Id = -14,//ID = -1,
//    Name = "C#",
//    Desc = "abc",
//    //Course_id = -1,
//    StartTime = DateTime.ParseExact("01/12/2022", "dd/MM/yyyy",
//CultureInfo.InvariantCulture/*null*/),
//    Duration = TimeSpan.FromHours(100)
//},
//new Module
//{
//    Id = -15,//ID = -2,
//    Name = "Azure",
//    Desc = "def",
//    //Course_id = -2,
//    StartTime = DateTime.ParseExact("15/01/2023", "dd/MM/yyyy",
//CultureInfo.InvariantCulture/*null*/),
//    Duration = TimeSpan.FromHours(24)
//}
//);

//            modelBuilder.Entity<User>().HasData(
//new User
//{
//ID = -1,
//Name = "abcd",
//Email = "abcd@hotmail.com",
//Password = "abcd@hotmail.com",
//Course_id = -1
//},
//new User
//{
//ID = -2,
//Name = "efgh",
//Email = "efgh@hotmail.com",
//Password = "efgh@hotmail.com",
//Course_id = -2
//}
//);

            //modelBuilder.Entity<Membership>().HasData(
            //     new Membership { Id = 1, SocialSecurityNumber = "23409812-32134", FirstName = "Abc", LastName = "Def" }
            //new Membership { Id = 2, FullName = "123 934" },
            //new Membership { Id = 3, FullName = "AFS dfe" },
            //new Membership { Id = 4, FullName = "s73 fe2" }

            //);
        }




        //public DbSet<User> Users;
        //public DbSet<Course> Courses;
        //public DbSet<Module> Modules;
        //public DbSet<Activity> Activities;
        //public DbSet<ActivityType> ActivityTypes;



        //        public DbSet<GymClass> GymClasses => Set<GymClass>();
        //        public DbSet<ApplicationUserGymClass> AppUserGymClass => Set<ApplicationUserGymClass>();
        //        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        //            : base(options)
        //        {
        //        }

        //        protected override void OnModelCreating(ModelBuilder builder)
        //        {
        //            base.OnModelCreating(builder);

        //            builder.Entity<ApplicationUserGymClass>().HasKey(a => new { a.ApplicationUserId, a.GymClassId });

        //            builder.Entity<GymClass>().HasQueryFilter(g => g.StartTime > DateTime.UtcNow);
        //        }
        //    }
        //}

    }
