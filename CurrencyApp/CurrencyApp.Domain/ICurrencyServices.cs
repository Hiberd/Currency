using CSharpFunctionalExtensions;

namespace CurrencyApp.Domain
{
    public interface ICurrencyServices
    {
        public Task<Result<Currency>> Get(string id);

        public Task<Currency[]> GetAll(int tablePage, int pageSize);

        public Task CreateOrUpdate();
    }
}
