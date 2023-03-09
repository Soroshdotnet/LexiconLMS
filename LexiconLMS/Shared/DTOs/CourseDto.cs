using System.Diagnostics.CodeAnalysis;

namespace LexiconLMS.Client.Models
{

    public class CourseDto
    {

        public string Name { get; set; }
        public string Desc { get; set; }
        public ICollection<ModuleDto> Modules { get; set; }


    }
}