using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.DataContracts;
using TaxCalculator.Repository.Interfaces;

namespace TaxCalculator.Repository.Repository
{
    public class TaxQueryLogRepository: Repository<TaxQueryLog>, ITaxQueryLogRepository
    {
        public TaxQueryLogRepository(TaxCalculatorDbContext context) : base(context)
        {
        }
    }
}
