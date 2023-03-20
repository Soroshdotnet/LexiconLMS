using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace LexiconLMS.Shared.DTOs
{

    public class ActivityDto
    {

        public string Name { get; set; }
        public string Desc { get; set; }
        //public IEnumerable<ActivityTypeDto> ActivityTypes { get; set; }
        //public ICollection<ActivityTypeDto> TheActivityTypes { get; set; }
        public ActivityTypeDto ActivityType { get; set; }
        public string ActivityTypeName { get; set; }

    }
}