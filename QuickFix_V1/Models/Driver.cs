using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickFix_V1.Models
{
    public class Driver
    {
        [Key]
        public int Userid { get; set; }
        [Required (ErrorMessage = "Username field cannot be blank")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password field cannot be blank")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Phonenumber required")]
        public long Phonenumber { get; set; }

        //   public virtual Garage Garage { get; set; }

       


    }
}