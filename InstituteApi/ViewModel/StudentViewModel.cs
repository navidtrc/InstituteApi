using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstituteApi.ViewModel
{
    public class StudentViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public string LastName { get; set; }

        [Display(Name = "شماره دانشجویی")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public string Number { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل اشتباه است")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public string Email { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public string PhoneNumber { get; set; }

        [Display(Name = "تولد - میلادی")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "تولد - شمسی")]
        [Required(ErrorMessage = "{0} الزامی میباشد")]
        public string Birthdate_Persian { get; set; }
    }
}
