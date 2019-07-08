using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaxCalculator.DataContracts;
using TaxCalculator.Services.DTO;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services
{
    public class FlatRateTaxCalculatorService : ITaxCalculatorService
    {
        public Result Calculate(IncomeTax taxRate, decimal income)
        {
            var result = new Result
            {
                Description = string.Format("Tax calculate result for income {0}",
                    income.ToString("C")),
                TaxableIncome = income,
                Items = new Collection<ResultItem>()
            };

            foreach (var item in taxRate.TaxBrackets)
            {
                var taxItem = new ResultItem
                {
                    Name = item.Description,
                    Amount = item.TaxRate * income
                };

                result.Items.Add(taxItem);
            }

            return result;
        }

    }
}
