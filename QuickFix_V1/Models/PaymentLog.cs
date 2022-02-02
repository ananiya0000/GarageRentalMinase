using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickFix_V1.Models
{
    public class PaymentLog
    {
        [Key]
        public int PaymentID { get; set; }
        public string PaymentReason { get; set; }
        public int TotalPayment { get; set; }
        public int Userid { get; set; }
        public virtual Driver Driver { get; set; }
        public int GarageId { get; set; }
        public virtual Garage Garage { get; set; }
    }
}