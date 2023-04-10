﻿using ReportApp.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.DAL.Entities
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        [ForeignKey("AppUsers")]
        public Guid UserId { get; set; }

        public AppUsers User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
