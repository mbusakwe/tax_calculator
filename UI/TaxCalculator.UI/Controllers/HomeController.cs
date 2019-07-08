using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.DataContracts;
using TaxCalculator.Repository.Interfaces;
using TaxCalculator.Services;
using TaxCalculator.UI.Models;

namespace TaxCalculator.UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPostalCodeRepository _postalCodeRepository;
        private readonly IIncomeTaxRepository _incomeTaxRepository;
        private readonly ITaxQueryLogRepository _taxQueryLogRepository;

        public HomeController(IPostalCodeRepository postalCodeRepository, IIncomeTaxRepository incomeTaxRepository, ITaxQueryLogRepository taxQueryLogRepository)
        {
            _postalCodeRepository = postalCodeRepository;
            _incomeTaxRepository = incomeTaxRepository;
            _taxQueryLogRepository = taxQueryLogRepository;
        }

        public IActionResult Index()
        {
            var taxClaculationView = new TaxCalculateViewModel()
            {
                PostalCodes = _postalCodeRepository.GetAll()
            };
            return View(taxClaculationView);
        }

        [HttpPost]
        public IActionResult Index(TaxCalculateViewModel lendViewModel)
        {
            // update the database 
            var postalCode = _postalCodeRepository.GetById(lendViewModel.SelectedPostalCodeId);

            var incomeTax = _incomeTaxRepository.GetFullIncomeTax(postalCode.IncomeTaxId);

            var result = TaxCalculatorServiceFactory.GetTaxCalculatorService(
                        (DataContracts.TaxType)Enum.Parse(typeof(DataContracts.TaxType),
                        incomeTax.IncomeTaxType)).Calculate(incomeTax, lendViewModel.TaxableIncome);

            TaxResultViewModel taxResultViewModel = new TaxResultViewModel()
            {
                TaxableIncome = lendViewModel.TaxableIncome,
                TaxAmount = result.TotalAmount,
                TaxType = incomeTax.IncomeTaxType
            };

            var log = new TaxQueryLog()
            {
                 DateQueried = DateTime.Now,
                 PostCode = postalCode.PostCode,
                 TaxableIncome = lendViewModel.TaxableIncome,
                 TaxAmount = result.TotalAmount
            };

            _taxQueryLogRepository.Create(log);

            return RedirectToAction("TaxResult", taxResultViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TaxResult(TaxResultViewModel taxResultViewModel)
        {
            return View(taxResultViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
