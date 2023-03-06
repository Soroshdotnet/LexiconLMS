using System.Diagnostics.CodeAnalysis;

namespace LexiconLMS.Client.Models
{
    /*
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } }

        //nav props
        public ICollection<CourseModule> CourseModules { get; set; } = new List<CourseModule>();

        public ICollection<User>? users { get; set; } = new List<User>();

    }
    */

    public class CourseDto
    {

        public string Name { get; set; }


    }
}