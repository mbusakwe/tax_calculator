using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.DataContracts;
using TaxCalculator.Services.DTO;

namespace TaxCalculator.Services.Interfaces
{
    public interface ITaxCalculatorService
    {
        Result Calculate(IncomeTax taxRate, decimal income);
    }
}
