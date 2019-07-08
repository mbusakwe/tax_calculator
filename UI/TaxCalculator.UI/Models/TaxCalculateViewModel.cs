using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.DataContracts;

namespace TaxCalculator.UI.Models
{
    public class TaxCalculateViewModel
    {
        
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name ="Taxable Income")]
        public decimal TaxableIncome { get; set; }

        public int SelectedPostalCodeId { get; set; }


       
        [Display(Name = "Postal Codes")]
        public IEnumerable<PostalCode> PostalCodes { get; set; }

    }
}
