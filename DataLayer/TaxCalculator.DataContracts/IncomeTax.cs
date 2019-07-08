using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaxCalculator.DataContracts
{
    public class IncomeTax 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string IncomeTaxType { get; set; }
        public virtual ICollection<TaxBracket> TaxBrackets { get; set; }
    }

    [Flags]
    public enum TaxType
    {
        FlatValue = 1,
        FlatTaxRate = 2,
        Progressive = 3
    };
}
