using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaxCalculator.DataContracts
{
    public class TaxBracket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal StartIncome { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? EndIncome { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal BaseTax { get; set; }
        [Column(TypeName = "decimal(4, 3)")]
        public decimal TaxRate { get; set; }
        public int IncomeTaxId { get; set; }
        [ForeignKey("IncomeTaxId")]
        public virtual IncomeTax IncomeTax { get; set; }


    }
}
