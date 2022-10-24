using AutoMapper;
using CSharpFunctionalExtensions;
using CurrencyApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CurrencyApp.DataAccess
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly IMapper _mapper;
        private readonly CurrencyAppDbContext _dbContext;

        public CurrencyRepository(IMapper mapper, CurrencyAppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task Create(Currency currency)
        {
            var currencyEntity = _mapper.Map<Domain.Currency, Entities.Currency>(currency);

            await _dbContext.Currencies.AddAsync(currencyEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Currency currency)
        {
            var currencyEntity = _mapper.Map<Domain.Currency, Entities.Currency>(currency);

            var oldCurrency = await _dbContext.Currencies
                .FirstOrDefaultAsync(c => c.Id == currency.Id);

            if (oldCurrency != null)
            {
                oldCurrency.Value = currency.Value;
                oldCurrency.Name = currency.Name;
                oldCurrency.DateUpdate = currency.DateUpdate;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Currency> Get(string id)
        {
            var currency = await _dbContext.Currencies.FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<Entities.Currency, Domain.Currency>(currency);
        }

        public async Task<Currency[]> GetAll(int tablePage, int pageSize)
        {
            var currencies = await _dbContext.Currencies
                .Skip((tablePage - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToArrayAsync();

            return _mapper.Map<Entities.Currency[], Domain.Currency[]>(currencies);
        }
    }
}
