using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaxCalculator.Services.DTO
{
    public class ResultItem
    {
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}
