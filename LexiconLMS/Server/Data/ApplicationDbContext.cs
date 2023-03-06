using Duende.IdentityServer.EntityFramework.Options;
using LexiconLMS.Server.Models;
using LexiconLMS.Shared;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
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
        public DbSet<Activity_type> Activity_Types => Set<Activity_type>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<User> User => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Activity>().HasData(
                 new Activity { ID = -1, Desc = "abc", Activity_TypeID = -1, Module_id = -1, Name = "ABC" },
                   new Activity { ID = -2, Desc = "def", Activity_TypeID = -2, Module_id = -2, Name = "DEF" },
                   new Activity { ID = -3, Desc = "ghi", Activity_TypeID = -3, Module_id = -3, Name = "GHI" },
                   new Activity { ID = -4, Desc = "jkl", Activity_TypeID = -4, Module_id = -4, Name = "JKL" }
                );

            modelBuilder.Entity<Activity_type>().HasData(
     new Activity_type { ID = -1, Type = "Lesson" },
       new Activity_type { ID = -2, Type = "Test" }
    );

                            modelBuilder.Entity<ApplicationUser>().HasData(
     new ApplicationUser { Id = "-1", UserName = "abc", Email = "abc@hotmail.com" },
       new ApplicationUser { Id = "-2", UserName = "def", Email = "def@hotmail.com" }
    );

            modelBuilder.Entity<Course>().HasData(
new Course { ID = -1, Desc = "-1", Name = "Programming .NET"},
new Course { ID = -2, Desc = "-2", Name = "Programming Frontend" }
);

            modelBuilder.Entity<Document>().HasData(
new Document { ID = -1, Module_id = -1, Lesson_id = -1, Course_id = -1, Name = "E-learning" },
new Document { ID = -2, Module_id = -1, Lesson_id = -1, Course_id = -1, Name = "Slideshow" }
) ;

            modelBuilder.Entity<Module>().HasData(
new Module { ID = -1, Name = "C#", Desc = "abc", Course_id = -1,
    StartTime = DateTime.ParseExact("01/12/2022", "dd/MM/yyyy",
CultureInfo.InvariantCulture/*null*/),
    Duration = TimeSpan.FromHours(100)
},
new Module { ID = -2, Name = "Azure", Desc = "def", Course_id = -2,
    StartTime = DateTime.ParseExact("15/01/2023", "dd/MM/yyyy",
CultureInfo.InvariantCulture/*null*/), Duration = TimeSpan.FromHours(24)}
);

                 modelBuilder.Entity<User>().HasData(
new User { ID = -1, Name = "abcd", Email = "abcd@hotmail.com", 
    Password = "abcd@hotmail.com", Course_id = -1
},
new User { ID = -2, Name = "efgh", Email = "efgh@hotmail.com", 
    Password = "efgh@hotmail.com", Course_id = -2
}
);

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
        //public DbSet<Activity_type> Activity_types;



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
}