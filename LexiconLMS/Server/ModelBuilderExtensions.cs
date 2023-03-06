//using LexiconLMS.Server.Models;
//using Microsoft.AspNetCore.Cryptography.KeyDerivation;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Cryptography;

//namespace LexiconLMS.Server
//{
//    public static class ModelBuilderExtensions
//    {
//        public static void Seed(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<ApplicationUser>().HasData(
//                CreateApplicationUser("-10", "Dillion", "Password01"),
//                CreateApplicationUser("-11", "Tom", "Password02"),
//                CreateApplicationUser("-12", "David", "Password03")
//            );
//        }

//        public static ApplicationUser CreateApplicationUser(string id, string name, string password)
//        {
//            var applicationUser = new ApplicationUser();

//            byte[] salt = new byte[128 / 8];
//            using (var rng = RandomNumberGenerator.Create())
//            {
//                rng.GetBytes(salt);
//            }

//            //applicationUser.PasswordSalt = salt;
//            //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

//            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
//            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
//                password: password,
//                salt: salt,
//                prf: KeyDerivationPrf.HMACSHA1,
//                iterationCount: 10000,
//                numBytesRequested: 256 / 8));
//            applicationUser.Password = hashed;
//            applicationUser.Name = name;
//            applicationUser.Id = id;
//            return applicationUser;
//        }
//    }

//}
