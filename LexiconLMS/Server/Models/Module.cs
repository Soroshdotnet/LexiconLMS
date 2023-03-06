using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Server.Models
{
    public class Module
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }  
        public int Course_id { get; set; }
    }
}
