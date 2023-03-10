using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace LexiconLMS.Shared.DTOs
{

    public class UserDto
    {

        public string UserName { get; set; }
        public IEnumerable<ModuleDto> Modules { get; set; }
    }
}