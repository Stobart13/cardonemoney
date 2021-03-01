﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CardOneMoney.Models
{
    public class CustomerContext :DbContext
    {
        public CustomerContext() : base("CardOneMoney")
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}