﻿using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace LexiconLMS.Shared.DTOs
{
#nullable disable
    public class UserDto
    {

        public string UserName { get; set; }

        public CourseDto Course { get; set; }
        //public IEnumerable<ModuleDto> Modules { get; set; }
    }
}