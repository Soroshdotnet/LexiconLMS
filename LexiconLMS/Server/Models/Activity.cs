using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Server.Models
{
    public class Activity
    {
#nullable disable
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }



        public Module Module { get; set; }
        public int ModuleId { get; set; }

        public ActivityType ActivityType { get; set; }
        public int ActivityTypeId { get; set; }
    }
}
