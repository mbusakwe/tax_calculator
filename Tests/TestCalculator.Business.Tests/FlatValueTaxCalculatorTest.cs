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
    public class FlatValueTaxCalculatorTest
    {
        private readonly ITaxCalculatorService _taxCalculator = TaxCalculatorServiceFactory.GetTaxCalculatorService(TaxType.FlatValue);
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
                        TaxRate = 0.08m,
                        IncomeTaxId = 1,
                        Id = 1,
                        BaseTax = 20000m,
                        Description = "",
                        EndIncome = 150000m
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
            Assert.AreEqual(_taxCalculator.Calculate(taxRate, income).TotalAmount, 1200m);

        }

        [Test]
        public void Test_Calculate_Flat_Rate_Tax_190000()
        {
            // ARRANGE 
            var income = 190000m;

            //ASSERT
            Assert.AreEqual(_taxCalculator.Calculate(taxRate, income).TotalAmount, 20000m);

        }
    }
}
