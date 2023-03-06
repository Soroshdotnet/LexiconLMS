using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public byte[] PasswordSalt { get; set; }
        public int Course_id { get; set; }
    }
}