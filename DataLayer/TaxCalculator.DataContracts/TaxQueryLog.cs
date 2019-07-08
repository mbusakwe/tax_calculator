using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaxCalculator.DataContracts
{
    public class TaxQueryLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PostCode { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TaxableIncome { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TaxAmount { get; set; }
        public DateTime DateQueried { get; set; }

    }
}
