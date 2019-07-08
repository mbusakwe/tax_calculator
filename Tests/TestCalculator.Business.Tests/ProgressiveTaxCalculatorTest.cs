using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.DataContracts;
using TaxCalculator.Services;
using TaxCalculator.Services.Interfaces;

namespace TestCalculator.Business.Tests
{
    public class ProgressiveTaxCalculatorTest
    {

        private ITaxCalculatorService _taxCalculator = TaxCalculatorServiceFactory.GetTaxCalculatorService(TaxType.Progressive);

        private readonly IncomeTax _taxRate = new IncomeTax
        {
            Id = 1,
            TaxBrackets = new List<TaxBracket>
            {
                new TaxBracket {StartIncome = 0m, EndIncome = 10000m, TaxRate = 0.1m},
                new TaxBracket {StartIncome = 10001m, EndIncome = 30000m, TaxRate = 0.2m},
                new TaxBracket {StartIncome = 30001m, EndIncome = null, TaxRate = 0.3m}

            }
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Calculate_Tax_50000()
        {
            // 133510
            var result = _taxCalculator.Calculate(_taxRate, 50000m);
            Assert.AreEqual(11000M, result.TotalAmount);
        }

        [Test]
        public void Test_Calculate_Tax_22000()
        {
            var result = _taxCalculator.Calculate(_taxRate, 22000m);
            Assert.AreEqual(3400m, result.TotalAmount);
        }

    }
}
