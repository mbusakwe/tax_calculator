using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculator.DataContracts
{
    public class PostalCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(4)]
        public string PostCode { get; set; }
        public int IncomeTaxId { get; set; }
        [ForeignKey("IncomeTaxId")]
        public virtual IncomeTax IncomeTax { get; set; }
    }
}
