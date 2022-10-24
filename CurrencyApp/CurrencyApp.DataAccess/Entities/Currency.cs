namespace CurrencyApp.DataAccess.Entities
{
    public class Currency
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
