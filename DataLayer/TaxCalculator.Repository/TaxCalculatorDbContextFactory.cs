using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Repository
{
    public class TaxCalculatorDbContextFactory : IDesignTimeDbContextFactory<TaxCalculatorDbContext>
    {
        public TaxCalculatorDbContext CreateDbContext(string[] args)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<TaxCalculatorDbContext>();
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=IncomeTaxDatabase;Trusted_Connection=True;");
            // Server=(localdb)\\mssqllocaldb;Database=aspnet-TaxCalculator.UI-996B767C-B197-4058-8426-EAD7E731083F;Trusted_Connection=True;MultipleActiveResultSets=true
            return new TaxCalculatorDbContext(optionsBuilder.Options);
        }
    }
}
