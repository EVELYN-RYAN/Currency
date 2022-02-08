using System;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Currency.Models
{
    public class CurrencyContext : DbContext
    {
        // Constructor
        public CurrencyContext(DbContextOptions<CurrencyContext> options) : base(options)
        {
            
        }
        public DbSet<Currency> Currency { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Currency>().HasData(
                new Currency
                {
                    CurrencyID = 1,
                    CurrencyFullName = "US Dollar",
                    CurrencyCode = "USD",
                    Unit = "$",
                    Rate = 40694.543m,
                    PrevRate = 40694.543m
                },
                new Currency
                {
                    CurrencyID = 2,
                    CurrencyFullName = "Bitcoin",
                    CurrencyCode = "BTC",
                    Unit = "₿",
                    Rate = 1.0m,
                    PrevRate = 1.0m
                },
                new Currency
                {
                    CurrencyID = 3,
                    CurrencyFullName = "Philippine Peso",
                    CurrencyCode = "PHP",
                    Unit = "₱",
                    Rate = 2083596.208m,
                    PrevRate = 2083596.208m
                });
        }

    }
}
