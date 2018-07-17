using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CCValidator.Models
{
    public class CreditCardViewModel
    { 
        public decimal CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}