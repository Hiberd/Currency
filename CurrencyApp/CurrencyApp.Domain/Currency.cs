namespace CurrencyApp.Domain
{
    public record Currency
    {
        public string Id { get; set; }

        public string Name { get; init; }

        public decimal Value { get; init; }

        public DateTime DateUpdate { get; init; }
    }
}
