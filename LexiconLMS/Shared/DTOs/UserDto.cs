using System.Diagnostics.CodeAnalysis;
using System.Reflection;

//using LexiconLMS.Server.Models
namespace LexiconLMS.Shared.DTOs
{
#nullable disable
    public class UserDto
    {
        //public ApplicationUserDto
        public string UserName { get; set; }
        public string FullName { get; set; }

        public CourseDto Course { get; set; }
        //public IEnumerable<ModuleDto> Modules { get; set; }
    }
}