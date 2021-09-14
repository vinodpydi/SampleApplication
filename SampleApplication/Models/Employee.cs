using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleApplication.Models
{
    public class Employee
    {
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Please Provide Firstname", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Please Provide Lastname", AllowEmptyStrings = false)]
        public string LastName { get; set; }
    }
}