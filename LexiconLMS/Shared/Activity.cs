using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Shared
{
    public class Activity
    {
        public int UniqueID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int Module_id { get; set; }
        public int Activity_TypeID { get; set; }
    }
}
