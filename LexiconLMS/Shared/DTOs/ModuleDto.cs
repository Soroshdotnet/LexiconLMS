using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace LexiconLMS.Client.Models
{

    public class ModuleDto
    {

        public string Name { get; set; }
        public string Desc { get; set; }
        public ICollection<ActivityDto> Activitys { get; set; }

    }
}