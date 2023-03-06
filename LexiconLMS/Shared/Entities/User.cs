using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Shared.Entities
{
    public class User
    {
        [Key]
        public int UniqueId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Course CourseId{ get; set; }
        public IEnumerable<Document> Document { get; set; }
    }
}
