using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Server.Models
{
    public class CreateCourse
    {
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string? Name { get; set; } = string.Empty;
    }
}
