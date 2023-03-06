using LexiconLMS.Shared;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Server.Models
{
#nullable disable
    public class ApplicationUser : IdentityUser
    {
        public int? CourseId { get; set; }
        public Course Course { get; set; }

    }
}