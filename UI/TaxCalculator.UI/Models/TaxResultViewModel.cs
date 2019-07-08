using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculator.UI.Models
{
    public class TaxResultViewModel
    {

        [DataType(DataType.Currency)]
        [Display(Name = "Taxable Income")]
        public decimal TaxableIncome { get; set; }

        [DataType(DataType.Currency)]
        public decimal TaxAmount { get; set; }

        public string TaxType { get; set; }
    }
}
