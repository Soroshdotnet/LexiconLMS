using System.Diagnostics.CodeAnalysis;

namespace LexiconLMS.Shared.DTOs
{

    public class CourseDto
    {
#nullable disable
        public string Name { get; set; }
        public string Desc { get; set; }
        public IEnumerable<ModuleDto> Modules { get; set; }
        public IEnumerable<UserDto> Users { get; set; }



    }
}