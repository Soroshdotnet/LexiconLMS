namespace LexiconLMS.Client.Models
{
    public class CourseModule
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } }

        //Foreign keys
        public int CourseId { get; set; }

        //nav props
        public ICollection<CourseModuleActivity> CourseModuleActivities { get; set; } = new List<CourseModuleActivity>();

        public Course? Course { get; set; }

    }
}
