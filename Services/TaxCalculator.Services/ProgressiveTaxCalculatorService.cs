using System;
using System.Collections.ObjectModel;
using System.Linq;
using TaxCalculator.DataContracts;
using TaxCalculator.Services.DTO;

namespace TaxCalculator.Services
{
    public class ProgressiveTaxCalculatorService : Interfaces.ITaxCalculatorService
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

            var applicableTaxes = taxRate.TaxBrackets.Where(t => t.StartIncome < income);

            foreach(var item in applicableTaxes)
            {
                var taxItem = new ResultItem()
                {
                    Name = item.Description
                };

                var startIncome = item.StartIncome;
                if(startIncome > 0)
                {
                    startIncome -= 1;
                }

                if(item.EndIncome.HasValue == false || item.EndIncome.Value > income)
                {
                    taxItem.Amount = (income - startIncome) * item.TaxRate;
                }
                else
                {
                    taxItem.Amount = (item.EndIncome.Value - startIncome) * item.TaxRate;
                }
                result.Items.Add(taxItem);
            }

            return result;
        }

    }
}
