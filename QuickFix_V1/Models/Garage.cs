using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuickFix_V1.Models
{
    public class Garage
    {
        [Key]
        public int GarageId { get; set; }
        [Required(ErrorMessage = "please enter the garage names")]
        public string GarageName { get; set; }
        [Required(ErrorMessage = "password field required")]
        public string Password { get; set; }

        public string Location { get; set; }
        [Required(ErrorMessage = "enter the number of your employees")]
        public int NumberOfEmployees { get; set; }
        [Required(ErrorMessage = "enter your tin number")]
        public long TinNumber { get; set; }
    }
}