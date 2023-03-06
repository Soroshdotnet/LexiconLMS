using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Shared
{
    public class Document
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Module_id { get; set; }
        public int Lesson_id { get; set; }
        public int Course_id { get; set; }
    }
}
