using InstituteApi.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstituteApi.ViewModel
{
    public class CourseViewModel
    {
        [Display(Name = "Id")]        
        public int Id { get; set; }
        [Display(Name = "نام دوره")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public string Title { get; set; }
        [Display(Name = "استاد")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public string Instructor { get; set; }
        [Display(Name = "تاریخ شروع دوره - میلادی")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "تاریخ شروع دوره - شمسی")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public string StartDate_Persian { get; set; }

        [Display(Name = "مدت زمان دوره (ساعت)")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public int Duration { get; set; }
        [Display(Name = "روز های برگذاری")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public List<int> HoldingDays { get; set; }
        [Display(Name = "ساعت شروع")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public TimeSpan HourBegin { get; set; }
        [Display(Name = "ساعت پایان")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public TimeSpan HourEnd { get; set; }
        
    }
}
