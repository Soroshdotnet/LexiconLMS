using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Shared.DTOs
{
    public class CreateModuleDto
    {
#nullable disable
        [Required]
        [StringLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
        public string Desc { get; set; }


        //ToDo  Enddate cant be before startdate
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }

        public int  CourseId { get; set; }


    }
}