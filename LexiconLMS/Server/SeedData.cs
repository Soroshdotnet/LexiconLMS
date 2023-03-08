﻿using Bogus;
using LexiconLMS.Server.Models;
using LexiconLMS.Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexiconLMS.Shared;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LexiconLMS.Server
{
    public class SeedData
    {
        private static ApplicationDbContext db = default!;
        private static RoleManager<IdentityRole> roleManager = default!;
        private static UserManager<ApplicationUser> userManager = default!;
        public static async Task InitAsync(ApplicationDbContext context, IServiceProvider services, string adminPW)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            db = context;
            if (db.Users.Any()) return;
            ArgumentNullException.ThrowIfNull(nameof(services));
            //ArgumentNullException.ThrowIfNull(adminPW, nameof(adminPW));

            roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            ArgumentNullException.ThrowIfNull(roleManager);

            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            ArgumentNullException.ThrowIfNull(userManager);

            var roleNames = new[] { "Member", "Admin" };
            var adminEmail = "admin@gym.se";

            var users = GetUsers(20);
            await db.AddRangeAsync(users);

            await AddRolesAsync(roleNames);

            var admin = await AddAdminAsync(adminEmail, adminPW);

            await AddToRolesAsync(admin, roleNames);
        }

        private static async Task AddToRolesAsync(ApplicationUser admin, string[] roleNames)
        {
            foreach (var role in roleNames)
            {
                if (await userManager.IsInRoleAsync(admin, role)) continue;
                var result = await userManager.AddToRoleAsync(admin, role);
                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }

        private static async Task<ApplicationUser> AddAdminAsync(string adminEmail, string adminPW)
        {
            var found = await userManager.FindByEmailAsync(adminEmail);

            if (found != null) return null!;

            var admin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                //FirstName = "Admin",
                //TimeOfRegistration = DateTime.Now
            };

            var result = await userManager.CreateAsync(admin, adminPW);
            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

            return admin;
        }

        private static async Task AddRolesAsync(string[] roleNames)
        {
            foreach (var roleName in roleNames)
            {
                if (await roleManager.RoleExistsAsync(roleName)) continue;
                var role = new IdentityRole { Name = roleName };
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }

        private static IEnumerable<ApplicationUser> GetUsers(int nrOfUsers)
        {
            var faker = new Faker("sv");

            var users = new List<ApplicationUser>();

            for (int i = 0; i < nrOfUsers; i++)
            {
                var temp = new ApplicationUser
                {
                    //Name = faker.Company.CatchPhrase(),
                    Email = faker.Hacker.Verb(),
                    PasswordHash = faker.Random.ToString()
                    //Duration = new TimeSpan(0, 55, 0),
                    //StartTime = DateTime.Now.AddDays(faker.Random.Int(-5, 5))
                };

                users.Add(temp);
            }

            return users;
        }

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
//new ApplicationUser
//{
//    Id = "-1",
//    UserName = "abc",
//    Email = "abc@hotmail.com"
//    /*, Name = "ABC", *//*Password = "abc", *//*Course_id = -1*/
//},
//new ApplicationUser
//{
//    Id = "-2",
//    UserName = "def",
//    Email = "def@hotmail.com"
//    //,
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

        private static IEnumerable<Module> GetModules(int nrOfModules)
        {
            var faker = new Faker<Module>("sv")
                .RuleFor(g => g.Name, f => f.Company.CatchPhrase())
                .RuleFor(g => g.Desc, f => f.Hacker.Verb())
                .RuleFor(g => g.Duration, new TimeSpan(0, 55, 0))
                .RuleFor(g => g.StartTime, f => DateTime.Now.AddDays(f.Random.Int(-5, 5)));

            return faker.Generate(nrOfModules);
        }
    }
}
