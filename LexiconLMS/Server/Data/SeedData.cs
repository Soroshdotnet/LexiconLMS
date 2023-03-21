using Bogus;
using LexiconLMS.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Server.Data
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
                FirstName = "Student",
                LastName = "LMS",
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
                g.StartDate = DateTime.Now.AddDays(f.Random.Int(-5, 5));
                g.EndDate = DateTime.Now.AddDays(f.Random.Int(5, 30));
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