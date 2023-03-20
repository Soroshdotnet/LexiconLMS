using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Server.Models
{
#nullable disable
    public class ApplicationUser : IdentityUser
    {
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}