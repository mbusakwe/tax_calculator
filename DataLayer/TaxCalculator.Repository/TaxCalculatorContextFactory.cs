using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Repository
{
    public class TaxCalculatorContextFactory: IDesignTimeDbContextFactory<TaxCalculatorDbContext>
    {
        public TaxCalculatorDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaxCalculatorDbContext>();
            var cs = @"Server=.\SQLExpress;AttachDbFilename=|DataDirectory|\mydbfile.mdf;Database=dbname;Trusted_Connection=Yes;";

            optionsBuilder.UseSqlServer(cs);

            return new TaxCalculatorDbContext(optionsBuilder.Options);
        }
    }
}
