using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Shared.Entities
{
    public class Document
    {
        public int UniqueId { get; set; }

        public int? ModuleId { get; set; }
        public int? LessonId { get; set; }
        public int? CourseId { get; set; }
    }
}
