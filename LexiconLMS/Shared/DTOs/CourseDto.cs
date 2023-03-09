using System.Diagnostics.CodeAnalysis;

namespace LexiconLMS.Client.Models
{

    public class CourseDto
    {

        public string Name { get; set; }
        public string Desc { get; set; }
        public IEnumerable<ModuleDto> Modules { get; set; }


    }
}