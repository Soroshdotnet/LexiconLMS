namespace LexiconLMS.Server.Models
{
    public class CourseModuleActivity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } }

        //Foreign keys
        public int CourseModuleId { get; set; }

        //Nav prop
        public CourseModule? CourseModule { get; set; }
    }
}
