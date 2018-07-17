using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CCValidator.Models
{
    public class CreditCardValidity
    { 
        public decimal CardNumber { get; set; }
        public bool IsValid { get; set; }
        public string BrandName { get; set; }
        public string Error { get; set; }
    }
}