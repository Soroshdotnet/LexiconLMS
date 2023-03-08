using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Server.Models
{
    public class ActivityType
    {

#nullable disable

        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;

        public ICollection<Activity> Activitys { get; set;}
    }
}
