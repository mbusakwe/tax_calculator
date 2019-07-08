using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TaxCalculator.DataContracts;
using TaxCalculator.Services;
using TaxCalculator.Services.Interfaces;

namespace TestCalculator.Business.Tests
{
    public class FlatRateTaxCalculatorTest
    {

        private readonly ITaxCalculatorService _taxCalculator = TaxCalculatorServiceFactory.GetTaxCalculatorService(TaxType.FlatTaxRate);
        private IncomeTax taxRate; 

        [SetUp]
        public void Setup()
        {

            taxRate = new IncomeTax()
            {
                Description = "",
                Id = 1,
                TaxBrackets = new Collection<TaxBracket>
                {
                    new TaxBracket()
                    {
                        TaxRate = 0.15m,
                        IncomeTaxId = 1,
                        Id = 1,
                        BaseTax = 0,
                        Description = ""
                    }
                }
            };
        }

        [Test]
        public void Test_Calculate_Flat_Rate_Tax_15000()
        {
            // ARRANGE 
            var income = 15000m;

            //ASSERT
            Assert.AreEqual(_taxCalculator.Calculate(taxRate, income).TotalAmount, 2250m);

        }
    }
}
