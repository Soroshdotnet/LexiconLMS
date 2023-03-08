using LexiconLMS.Server.Models;
using Microsoft.AspNetCore.Components.Routing;
using System.Reflection.PortableExecutable;

namespace LexiconLMS.Server.MyModels
{
    public class MockDataService
    {
        private static List<ApplicationUser>? _applicationUsers = default!;

        public static List<ApplicationUser> ApplicationUsers
        {
            get
            {
                //we will use these in initialization of Machines
                _applicationUsers ??= InitializeMockApplicationUser();

                return _applicationUsers;
            }
        }

        private static List<ApplicationUser> InitializeMockApplicationUser()
        {
            var e1 = new ApplicationUser
            {
                Id = "-20",
                //Name = "Kalle Anka",
                Email = "kalleanka@hotmail.com"
                //Course_id = -20

            };

            var e2 = new ApplicationUser
            {
                Id = "-20",
                //Name = "abcdefg",
                Email = "abcdefg@hotmail.com"
                //Course_id = -21
            };



            return new List<ApplicationUser>() { e1, e2 };
        }

        //private static List<JobCategory> InitializeMockJobCategories()
        //{
        //    return new List<JobCategory>()
        //    {
        //        new JobCategory{JobCategoryId = 1, JobCategoryName = "Pie research"},
        //        new JobCategory{JobCategoryId = 2, JobCategoryName = "Sales"},
        //        new JobCategory{JobCategoryId = 3, JobCategoryName = "Management"},
        //        new JobCategory{JobCategoryId = 4, JobCategoryName = "Store staff"},
        //        new JobCategory{JobCategoryId = 5, JobCategoryName = "Finance"},
        //        new JobCategory{JobCategoryId = 6, JobCategoryName = "QA"},
        //        new JobCategory{JobCategoryId = 7, JobCategoryName = "IT"},
        //        new JobCategory{JobCategoryId = 8, JobCategoryName = "Cleaning"},
        //        new JobCategory{JobCategoryId = 9, JobCategoryName = "Bakery"},
        //        new JobCategory{JobCategoryId = 9, JobCategoryName = "Bakery"}
        //    };
        //}

        //private static List<Country> InitializeMockCountries()
        //{
        //    return new List<Country>
        //    {
        //        new Country {CountryId = 1, Name = "Belgium"},
        //        new Country {CountryId = 2, Name = "Netherlands"},
        //        new Country {CountryId = 3, Name = "USA"},
        //        new Country {CountryId = 4, Name = "Japan"},
        //        new Country {CountryId = 5, Name = "China"},
        //        new Country {CountryId = 6, Name = "UK"},
        //        new Country {CountryId = 7, Name = "France"},
        //        new Country {CountryId = 8, Name = "Brazil"}
        //    };
        //}
    }
}

