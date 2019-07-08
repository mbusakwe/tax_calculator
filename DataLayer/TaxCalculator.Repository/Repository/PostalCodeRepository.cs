using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.DataContracts;
using TaxCalculator.Repository.Interfaces;

namespace TaxCalculator.Repository.Repository
{
    public class PostalCodeRepository: Repository<PostalCode>, IPostalCodeRepository
    {
        public PostalCodeRepository(TaxCalculatorDbContext context): base(context)
        {
        }
    }
}
