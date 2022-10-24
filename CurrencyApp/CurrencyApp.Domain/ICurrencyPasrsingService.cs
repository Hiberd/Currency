namespace CurrencyApp.Domain
{
    public interface ICurrencyPasrsingService
    {
        public Task<Currency[]> GetParsed();
    }
}
