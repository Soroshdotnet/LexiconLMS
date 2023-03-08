using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Server.Models
{
    public class Module
    {
#nullable disable
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }  


        public Course Course { get; set; }
        public int CourseId { get; set; }


        public ICollection<Activity> Activitys { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
