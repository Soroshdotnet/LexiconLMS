using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Shared.Entities
{
    public class Course
    {
        [Key]
        public int UniqueId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;

        public IEnumerable<Document> Document { get; set; }

    }
}
