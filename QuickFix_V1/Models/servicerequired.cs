using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickFix_V1.Models
{

    public class servicerequired
    {
        [Key]
        public int serviceid { get; set; }
        [Required(ErrorMessage = "service type is mandatory")]
        public string Servicerequired { get; set; }
        [Required(ErrorMessage = "car model is required")]
        public string carmodel { get; set; }
        [Required(ErrorMessage = "car brand required")]
        public string carbrand { get; set; }
        [Required(ErrorMessage = "location mandatory")]
        public string location { get; set; }
        public int Userid { get; set; }
        public virtual Driver Driver { get; set; }
        public int GarageId { get; set; }
        public virtual Garage Garage { get; set; }
    }
}