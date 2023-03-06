using System.Diagnostics.CodeAnalysis;

namespace LexiconLMS.Server.Models
{

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

        public ICollection<ApplicationUser>? ApplicationUserGymClasses { get; set; } = new List<ApplicationUser>();

    }
}
