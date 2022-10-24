using CurrencyApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyApp.DataAccess
{
    public class CurrencyAppDbContext : DbContext
    {
        public CurrencyAppDbContext(DbContextOptions<CurrencyAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; } = null!;
    }
}
