using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Shared.Entities
{
    public class Module
    {
        public int UniqueId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime Duration { get; set; }
        public Course Course { get; set; }
        public IEnumerable<Document> Document { get; set; }

    }
}
