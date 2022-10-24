namespace CurrencyApp.Domain
{
    public interface ICurrencyRepository
    {
        public Task<Currency> Get(string id);

        public Task<Currency[]> GetAll(int tablePage, int pageSize);

        public Task Create(Currency currency);

        public Task Update(Currency currency);
    }
}
