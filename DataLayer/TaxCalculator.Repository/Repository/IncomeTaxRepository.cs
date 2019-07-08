using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxCalculator.DataContracts;
using TaxCalculator.Repository.Interfaces;

namespace TaxCalculator.Repository.Repository
{
    public class IncomeTaxRepository: Repository<IncomeTax>, IIncomeTaxRepository
    {
        public IncomeTaxRepository(TaxCalculatorDbContext context):base(context)
        {
        }

        public IncomeTax GetFullIncomeTax(int id)
        {
            return _context.IncomeTaxes
                          .Where(a => a.Id == id)
                          .Include(a => a.TaxBrackets)
                    .FirstOrDefault();

        }
    }
}
