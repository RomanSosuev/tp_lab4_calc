using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplicationLab4.Models
{
    public class Calc
    {
        [Required(ErrorMessage = "Enter a required Operand1")]
        [Display(Name = "Operand 1")]
        public sbyte OP1 { get; set; }



        [Range(-100, 100,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Operand 2")]
        public decimal OP2 { get; set; }


        public decimal Result { get; set; }
        public string Operation { get; set; }
    }
}