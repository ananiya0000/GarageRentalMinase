using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickFix_V1.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "StringLength exceded is 30")]
        public string Password { get; set; }
        [Required]
      
        public virtual Garage Garage { get; set; }
       // public virtual Driver Driver { get; set; }
    }
}