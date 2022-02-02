using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuickFix_V1.Models
{
    public class ApplicationDBContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Garage> Garages { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<PaymentLog> PaymentLogs { get; set; }

        public virtual DbSet<servicerequired> Servicerequireds { get; set; }
       
      

    }
}