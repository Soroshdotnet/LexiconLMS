﻿using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Shared.DTOs
{
    public class CreateCourseDto
    {
#nullable disable
        [Required]
        [StringLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
        public string Desc { get; set; }


        //ToDo  Enddate cant be before startdate
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



    } 
}