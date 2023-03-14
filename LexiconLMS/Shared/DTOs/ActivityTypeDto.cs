using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Shared.DTOs
{
    public class ActivityTypeDto
    {
#nullable disable

        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;

        public ICollection<Activity> Activitys { get; set; }
    }
}
