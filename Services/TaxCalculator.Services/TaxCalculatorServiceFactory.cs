using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.DataContracts;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services
{
    public class TaxCalculatorServiceFactory
    {
        public static ITaxCalculatorService GetTaxCalculatorService(TaxType taxType)
        {
            ITaxCalculatorService taxCalculatorService = null;
            switch (taxType)
            {
                case TaxType.FlatTaxRate:
                    taxCalculatorService = new FlatRateTaxCalculatorService();
                    break;
                case TaxType.FlatValue:
                    taxCalculatorService = new FlatValueTaxCalculatorService();
                    break;
                case TaxType.Progressive:
                    taxCalculatorService = new ProgressiveTaxCalculatorService();
                    break;
                default:
                    throw new ApplicationException(string.Format("The tax type '{0}' supplied is not supported.", taxType.ToString()));
            }

            return taxCalculatorService;
        }
    }
}
