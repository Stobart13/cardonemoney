using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CardOneMoney.Models
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime DateApplied { get; set; }
    }
}