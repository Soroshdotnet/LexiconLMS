using Bogus;
using LexiconLMS.Server.Models;
using LexiconLMS.Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Server
{
    public class SeedData
    {
        private static ApplicationDbContext db = default!;
        private static RoleManager<IdentityRole> roleManager = default!;
        private static UserManager<ApplicationUser> userManager = default!;
        private static string? adminPW;

        public static async Task InitAsync(ApplicationDbContext context, IServiceProvider services)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            db = context;
            if (db.Users.Any()) return;
            ArgumentNullException.ThrowIfNull(nameof(services));

            roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            ArgumentNullException.ThrowIfNull(roleManager);

            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            ArgumentNullException.ThrowIfNull(userManager);

            //--------------
            adminPW = "BytMig123!";
            //--------------

            var roleNames = new[] { "Teacher", "Student" };
            var teacherEmail = "teacher@lms.se";

            var studentEmail = "student@lms.se";


            await CreateRoles(roleNames);

            var courses = GetCourses(5);
            db.AddRange(courses);

            var modules = GetModules(50, courses);
            db.AddRange(modules);

            var activities = GetActivites(300, modules);
            db.AddRange(activities);

            await CreateStudents(100, roleNames[1], courses);

            var teacher = await AddTeacherAsync(teacherEmail, adminPW);
            await AddToRoleAsync(teacher, roleNames[0]);            
            
            var student = await AddStudentAsync(studentEmail, adminPW);
            await AddToRoleAsync(student, roleNames[1]);

            await db.SaveChangesAsync();
        }

        private static async Task CreateRoles(string[] roleNames)
        {
            foreach (var roleName in roleNames)
            {
                if (await roleManager.RoleExistsAsync(roleName)) continue;
                var role = new IdentityRole { Name = roleName };
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }

        private static async Task CreateStudents(int nrOfUsers, string role, IEnumerable<Course> courses)
        {

            var users = new List<ApplicationUser>();

            for (int i = 0; i < nrOfUsers; i++)
            {
               var faker = new Faker("sv");
                var firstName = faker.Person.FirstName;
                var lastName = faker.Person.LastName;
                var email = faker.Internet.Email(firstName, lastName);

                var temp = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Course = faker.PickRandom(courses)

                };

                var res = await userManager.CreateAsync(temp, adminPW!);
                if (!res.Succeeded) throw new Exception(string.Join("\n", res.Errors));

                await AddToRoleAsync(temp, role);

            }


        }

        private static async Task AddToRoleAsync(ApplicationUser teacher, string roleName)
        {
            var result = await userManager.AddToRoleAsync(teacher, roleName);
            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
        }

        private static async Task<ApplicationUser> AddTeacherAsync(string teacherEmail, string adminPW)
        {
            var found = await userManager.FindByEmailAsync(teacherEmail);

            if (found != null) return null!;

            var teacher = new ApplicationUser
            {
                UserName = teacherEmail,
                Email = teacherEmail,
                FirstName = "Teacher",
                LastName = "LMS"
            };

            var result = await userManager.CreateAsync(teacher, adminPW);
            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

            return teacher;            
        }

        private static async Task<ApplicationUser> AddStudentAsync(string studentEmail, string adminPW)
        {
            var found = await userManager.FindByEmailAsync(studentEmail);

            if (found != null) return null!;

            var student = new ApplicationUser
            {
                UserName = studentEmail,
                Email = studentEmail,
                CourseId = 2,
            };

            var result = await userManager.CreateAsync(student, adminPW);
            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

            return student;
        }

        private static IEnumerable<Course> GetCourses(int nrOfCourses)
        {
            var faker = new Faker<Course>("sv").Rules((f, g) =>
            {
                g.Name = f.Company.CatchPhrase();
                g.Desc = f.Hacker.Verb();
                //g.Duration = new TimeSpan(0, 55, 0);
                //g.StartTime = DateTime.Now.AddDays(f.Random.Int(-5, 5));
            });

            return faker.Generate(nrOfCourses);
        }

        private static IEnumerable<Module> GetModules(int nrOfModules, IEnumerable<Course> courses)
        {
            var faker = new Faker<Module>("sv")
                .RuleFor(g => g.Name, f => f.Company.CatchPhrase())
                .RuleFor(g => g.Desc, f => f.Hacker.Verb())
                .RuleFor(g => g.Duration, new TimeSpan(0, 55, 0))
                .RuleFor(g => g.StartTime, f => DateTime.Now.AddDays(f.Random.Int(-5, 5)))
                .RuleFor(g => g.Course, f => f.PickRandom(courses));

            return faker.Generate(nrOfModules);
        }

        private static IEnumerable<Activity> GetActivites(int nrOfActivites, IEnumerable<Module> modules)
        {
            var activityTypes = new[] { "E-L", "Assignment", "Lecture" };
            List<ActivityType> activities = new List<ActivityType>();

            for (int i = 0; i < activityTypes.Length; i++)
            {
                var temp = new ActivityType
                {
                    Type = activityTypes[i],
                };
                activities.Add(temp);
            }

            db.AddRange(activities);


            var faker = new Faker<Activity>("sv")
                .RuleFor(g => g.Name, f => f.Company.CatchPhrase())
                .RuleFor(g => g.Desc, f => f.Hacker.Verb())
                .RuleFor(g => g.Duration, new TimeSpan(0, 55, 0))
                .RuleFor(g => g.StartTime, f => DateTime.Now.AddDays(f.Random.Int(-5, 5)))
                .RuleFor(g => g.Module, f => f.PickRandom(modules))
                .RuleFor(g => g.ActivityType, f => f.PickRandom(activities));

            return faker.Generate(nrOfActivites);
        }
    }
}
















//using Bogus;
//using LexiconLMS.Server.Models;
//using LexiconLMS.Server.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using LexiconLMS.Shared;
//using Microsoft.EntityFrameworkCore;
//using System.Globalization;
//using static Duende.IdentityServer.Models.IdentityResources;
//using Microsoft.AspNetCore.Components.Forms;

//namespace LexiconLMS.Server
//{
//    public class SeedData
//    {
//        private static ApplicationDbContext db = default!;
//        private static RoleManager<IdentityRole> roleManager = default!;
//        private static UserManager<ApplicationUser> userManager = default!;
//        private static string AdminPW = "BytMig123!";

//        public static async Task InitAsync(ApplicationDbContext context, IServiceProvider services/*, string adminPW*/)
//        {
//            ArgumentNullException.ThrowIfNull(nameof(context));
//            db = context;
//            if (db.Users.Any()) return;
//            ArgumentNullException.ThrowIfNull(nameof(services));
//            //ArgumentNullException.ThrowIfNull(adminPW, nameof(adminPW));

//            roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//            ArgumentNullException.ThrowIfNull(roleManager);

//            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//            ArgumentNullException.ThrowIfNull(userManager);
//            //string AdminPW = "BytMig123!";

//            var roleNames = new[] { "Teacher", "Student" };
//            var teacherEmail = "teacher@lms.se";

//            await CreateRoles(roleNames);
//                var courses = CreateCourses(20);
//            db.AddRange(courses);

//            var modules = GetModules(50, courses);
//            db.AddRange(modules);

//            var users = CreateStudents(5, roleNames[1], courses);

//            var users = GetUsers(20);
//            await db.AddRangeAsync(users);

//            await AddRolesAsync(roleNames);

//            var admin = await AddAdminAsync(adminEmail, adminPW);

//            await AddToRoleAsync(teacher, roleNames[0]);
//            await db.SaveChangesAsync();
//        }

//        private static async Task CreateRoles(/*ApplicationUser admin, */string[] roleNames)
//        {
//            foreach (var role in roleNames)
//            {
//                if (await userManager.IsInRoleAsync(admin, role)) continue;
//                var result = await userManager.AddToRoleAsync(admin, role);
//                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
//            }
//        }


//        //private static async Task AddToRolesAsync(ApplicationUser admin, string[] roleNames)
//        //{
//        //    foreach (var role in roleNames)
//        //    {
//        //        if (await userManager.IsInRoleAsync(admin, role)) continue;
//        //        var result = await userManager.AddToRoleAsync(admin, role);
//        //        if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
//        //    }
//        //}

//        private static async Task<ApplicationUser> AddTeacherAsync(string teacherEmail, string adminPW)
//        {
//            var found = await userManager.FindByEmailAsync(adminEmail);

//            if (found != null) return null!;

//            var admin = new ApplicationUser
//            {
//                UserName = adminEmail,
//                Email = adminEmail,
//                //FirstName = "Admin",
//                //TimeOfRegistration = DateTime.Now
//            };

//            var result = await userManager.CreateAsync(admin, adminPW);
//            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

//            return admin;
//        }

//        private static async Task AddToRoleAsync(ApplicationUser user, string[] roleNames)
//        {
//            foreach (var roleName in roleNames)
//            {
//                //if (await roleManager.RoleExistsAsync(roleName)) continue;
//                //var role = new IdentityRole { Name = roleName };
//                var result = await roleManager.CreateAsync(role);

//                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
//            }
//        }

//        private async Task<IEnumerable<ApplicationUser>> CreateStudents(int nrOfUsers, string role
//            ,IEnumerable<Course> courses)
//        {
//            var faker = new Faker("sv");

//            var users = new List<ApplicationUser>();

//            for (int i = 0; i < nrOfUsers; i++)
//            {
//                var email = faker.Internet.Email();/*faker.Hacker.Verb()*/
//                var temp = new ApplicationUser
//                {
//                    //Name = faker.Company.CatchPhrase(),
//                    Email = email,
//                    UserName = email,
//                    Course = faker.PickRandom(courses)
//                    //PasswordHash = faker.Random.ToString()
//                    //Duration = new TimeSpan(0, 55, 0),
//                    //StartTime = DateTime.Now.AddDays(faker.Random.Int(-5, 5))
//                };

///*var                */ var res = await userManager.CreateAsync(temp, AdminPW);
//        }

//            return users;
//        }

////        protected override void OnModelCreating(ModelBuilder modelBuilder)
////        {
////            base.OnModelCreating(modelBuilder);

////            //modelBuilder.Seed();


////            modelBuilder.Entity<Activity>().HasData(
////                 new Activity { Id = -11,/*ID = -1, Desc = "abc", ActivityTypeID = -1, Module_id = -1, */Name = "ABC" },
////                   new Activity { Id = -12,/*ID = -2, Desc = "def", ActivityTypeID = -2, Module_id = -2, */Name = "DEF" },
////                   new Activity { Id = -13,/*ID = -3, Desc = "ghi", ActivityTypeID = -3, Module_id = -3,*/ Name = "GHI" },
////                   new Activity { Id = -14,/*ID = -4, Desc = "jkl", ActivityTypeID = -4, Module_id = -4, */Name = "JKL" }
////                );

////            modelBuilder.Entity<ActivityType>().HasData(
////     new ActivityType { ID = -1, Type = "Lesson" },
////       new ActivityType { ID = -2, Type = "Test" }
////    );

////            modelBuilder.Entity<ApplicationUser>().HasData(
////new ApplicationUser
////{
////    Id = "-1",
////    UserName = "abc",
////    Email = "abc@hotmail.com"
////    /*, Name = "ABC", *//*Password = "abc", *//*Course_id = -1*/
////},
////new ApplicationUser
////{
////    Id = "-2",
////    UserName = "def",
////    Email = "def@hotmail.com"
////    //,
////    //Name = "DEF",
////    //Password = "def",
////    //Course_id = -2
////}
////);

////            modelBuilder.Entity<Course>().HasData(
////new Course { Id = -12,/*ID = -1, */Desc = "-1", Name = "Programming .NET" },
////new Course { Id = -13,/*ID = -2, */Desc = "-2", Name = "Programming Frontend" }
////);

////            modelBuilder.Entity<Document>().HasData(
////new Document { Id = -10/* ID = -1, Module_id = -1, Lesson_id = -1, Course_id = -1, Name = "E-learning"*/ },
////new Document { Id = -11/*ID = -2, Module_id = -1, Lesson_id = -1, Course_id = -1, Name = "Slideshow"*/ }
////);

////            modelBuilder.Entity<Module>().HasData(
////new Module
////{
////    Id = -14,//ID = -1,
////    Name = "C#",
////    Desc = "abc",
////    //Course_id = -1,
////    StartTime = DateTime.ParseExact("01/12/2022", "dd/MM/yyyy",
////CultureInfo.InvariantCulture/*null*/),
////    Duration = TimeSpan.FromHours(100)
////},
////new Module
////{
////    Id = -15,//ID = -2,
////    Name = "Azure",
////    Desc = "def",
////    //Course_id = -2,
////    StartTime = DateTime.ParseExact("15/01/2023", "dd/MM/yyyy",
////CultureInfo.InvariantCulture/*null*/),
////    Duration = TimeSpan.FromHours(24)
////}
////);

//            private static IEnumerable<Course> GetCourses(int nrOfCourses)
//        {
//            var faker = new Faker<Course>("sv").Rules((f, g) =>
//            {
//                g.Name = f.Company.CatchPhrase();
//                g.Desc = f.Hacker.Verb();
//                //g.Duration = new TimeSpan(0, 55, 0);
//                //g.StartTime = DateTime.Now.AddDays(f.Random.Int(-5, 5));
//            });

//            return faker.Generate(nrOfCourses);
//        }



//        private static IEnumerable<Module> GetModules(int nrOfModules, 
//            IEnumerable<Course> courses)
//        {
//            var faker = new Faker<Module>("sv")
//                .RuleFor(g => g.Name, f => f.Company.CatchPhrase())
//                .RuleFor(g => g.Desc, f => f.Hacker.Verb())
//                .RuleFor(g => g.Duration, new TimeSpan(0, 55, 0))
//                .RuleFor(g => g.StartTime, f => DateTime.Now.AddDays(f.Random.Int(-5, 5)))
//                        .RuleFor(g => g.Course, f => DateTime.Now.AddDays(f.Random.Int(-5, 5)));


//            return faker.Generate(nrOfModules);
//        }

//    private static IEnumerable<Activity> GetActivities(int nrOfActivites,
//            IEnumerable<Module> modules)
//    {
//        var activityTypes = new[] { "E-L", "Assignment", "Lecture" };


//        var faker = new Faker<Activity>("sv")
//            .RuleFor(g => g.Name, f => f.Company.CatchPhrase())
//            .RuleFor(g => g.Desc, f => f.Hacker.Verb())
//            .RuleFor(g => g.Duration, new TimeSpan(0, 55, 0))
//            .RuleFor(g => g.StartTime, f => DateTime.Now.AddDays(f.Random.Int(-5, 5)))
//                    .RuleFor(g => g.Module, f => f.PickRandom(modules));



//            return faker.Generate(nrOfModules);
//    }


//}
//}
