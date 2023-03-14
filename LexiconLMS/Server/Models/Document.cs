using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Server.Models
{
    public class Document
    {
#nullable disable

        public int Id { get; set; }

        public ApplicationUser ApplictionUser { get; set; }
        public string ApplictionUserId { get; set; }

        public Course Course { get; set; }
        public int? CourseId { get; set; }

        public Module Module { get; set; }
        public int? ModuleId { get; set; }
        public Activity Activity { get; set; }
        public int? ActivityId { get; set; }


    }
}
