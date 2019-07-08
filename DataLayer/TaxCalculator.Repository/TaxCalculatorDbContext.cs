using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TaxCalculator.DataContracts;

namespace TaxCalculator.Repository
{
    public class TaxCalculatorDbContext : DbContext
    {
        public TaxCalculatorDbContext(DbContextOptions<TaxCalculatorDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostalCode>()
                        .HasAlternateKey(c => c.PostCode)
                        .HasName("AlternateKey_PostCode");

            modelBuilder.Entity<IncomeTax>()
                        .HasAlternateKey(c => c.IncomeTaxType)
                        .HasName("AlternateKey_IncomeTaxType");

            modelBuilder.Entity<IncomeTax>().HasData(
                new IncomeTax { Id = 1, IncomeTaxType = TaxType.FlatTaxRate.ToString(), Description = "Flat Rate"},
                new IncomeTax { Id = 2, IncomeTaxType = TaxType.FlatValue.ToString(), Description = "Flat Value"},
                new IncomeTax { Id = 3, IncomeTaxType = TaxType.Progressive.ToString(), Description = "Progressive" }
            );

            modelBuilder.Entity<TaxBracket>().HasData(
                    new TaxBracket
                    {
                        Id = 1,
                        Description = "Flat Tax Rate",
                        TaxRate = 0.175m,
                        IncomeTaxId = 1,
                        BaseTax = 0m,
                        StartIncome = 0m
                    },
                    new TaxBracket
                    {
                         Id = 2,
                         Description = "Flat Value Tax",
                         TaxRate = 0.05m,
                         IncomeTaxId = 2,
                         BaseTax = 10000m,
                         StartIncome = 0m,
                         EndIncome = 200000m
                    },
                    new TaxBracket
                    {
                        Id = 3,
                        Description = "Progressive Tax Bracket 1",
                        TaxRate = 0.1m,
                        IncomeTaxId = 3,
                        BaseTax = 0,
                        StartIncome = 0m,
                        EndIncome = 8350m
                    },
                    new TaxBracket
                    {
                        Id = 4,
                        Description = "Progressive Tax Bracket 2",
                        TaxRate = 0.15m,
                        IncomeTaxId = 3,
                        BaseTax = 0,
                        StartIncome = 8351m,
                        EndIncome = 33950m
                    },
                    new TaxBracket
                    {
                        Id = 5,
                        Description = "Progressive Tax Bracket 3",
                        TaxRate = 0.25m,
                        IncomeTaxId = 3,
                        BaseTax = 0,
                        StartIncome = 33951m,
                        EndIncome = 82250m
                    },
                    new TaxBracket
                    {
                        Id = 6,
                        Description = "Progressive Tax Bracket 4",
                        TaxRate = 0.28m,
                        IncomeTaxId = 3,
                        BaseTax = 0,
                        StartIncome = 82251m,
                        EndIncome = 171550m
                    },
                    new TaxBracket
                    {
                        Id = 7,
                        Description = "Progressive Tax Bracket 5",
                        TaxRate = 0.33m,
                        IncomeTaxId = 3,
                        BaseTax = 0,
                        StartIncome = 171551m,
                        EndIncome = 372950m
                    },
                    new TaxBracket
                    {
                        Id = 8,
                        Description = "Progressive Tax Bracket 6",
                        TaxRate = 0.35m,
                        IncomeTaxId = 3,
                        BaseTax = 0,
                        StartIncome = 372951m
                    }
            );

            modelBuilder.Entity<PostalCode>().HasData(
                    new PostalCode { Id = 1, IncomeTaxId = 3, PostCode = "7441" },
                    new PostalCode { Id = 2, IncomeTaxId = 2, PostCode = "A100" },
                    new PostalCode { Id = 3, IncomeTaxId = 1, PostCode = "7000" },
                    new PostalCode { Id = 4, IncomeTaxId = 3, PostCode = "1000" }
            );

        }

        public virtual DbSet<IncomeTax> IncomeTaxes { get; set; }
        public virtual DbSet<PostalCode> PostalCodes { get; set; }
        public virtual DbSet<TaxQueryLog> TaxQueryLogs { get; set; }
        public DbSet<TaxBracket> TaxBrackets { get; set; }

    }
}
