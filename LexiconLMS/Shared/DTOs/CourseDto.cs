using System.Diagnostics.CodeAnalysis;

namespace LexiconLMS.Shared.DTOs
{

    public class CourseDto
    {
        public  int  Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<ModuleDto> Modules { get; set; }
        public IEnumerable<UserDto> Users { get; set; }



    }  
}