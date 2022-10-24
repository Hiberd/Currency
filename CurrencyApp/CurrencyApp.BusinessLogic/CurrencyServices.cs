using CSharpFunctionalExtensions;
using CurrencyApp.Domain;

namespace CurrencyApp.BusinessLogic
{
    public class CurrencyServices : ICurrencyServices
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICurrencyPasrsingService _currencyPasrsingService;

        public CurrencyServices(ICurrencyRepository currencyRepository, ICurrencyPasrsingService currencyPasrsingService)
        {
            _currencyRepository = currencyRepository;
            _currencyPasrsingService = currencyPasrsingService;
        }

        public async Task<Result<Currency>> Get(string id)
        {
            var currency = await _currencyRepository.Get(id);

            if (currency == null)
            {
                return Result.Failure<Currency>("Currencies with such an ID do not exist");
            }
            return currency;
        }

        public async Task<Currency[]> GetAll(int tablePage, int pageSize)
        {
            return await _currencyRepository.GetAll(tablePage, pageSize);
        }

        public async Task CreateOrUpdate()
        {
            var currencies = await _currencyPasrsingService.GetParsed();

            foreach (var currency in currencies)
            {
                var existCurrency = await _currencyRepository.Get(currency.Id);

                if (existCurrency == null)
                {
                    await _currencyRepository.Create(currency);
                }
                else
                {
                    await _currencyRepository.Update(currency);
                }
            }
        }
    }
}
