using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace LexiconLMS.Shared.DTOs
{
#nullable disable
    public class CreateCourseDto
    {
        [Required(ErrorMessage = "Titel is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Titel must be between 2 and 20 characters.")]
        public string Name { get; set; }

        public string Desc { get; set; }

        //ToDo  Enddate cant be before startdate

        [Required(ErrorMessage = "Start date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime StartDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "End date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(5);


    }





    //[StringLength(20, MinimumLength =2)]
    //public string Name { get; set; }
    //public string Desc { get; set; }
    //ToDo  Enddate cant be before startdate
    //public DateTime StartDate { get; set; }
    //public DateTime EndDate { get; set; }



}
