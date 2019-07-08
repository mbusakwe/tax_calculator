using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.DataContracts;

namespace TaxCalculator.Repository.Interfaces
{
    public interface IIncomeTaxRepository : IRepository<IncomeTax>
    {
        IncomeTax GetFullIncomeTax(int id);
    }
}
