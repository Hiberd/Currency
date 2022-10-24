using CurrencyApp.Domain;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CurrencyApp.BusinessLogic
{
    public class CurrencyPasrsingService : ICurrencyPasrsingService
    {
        private const string CurrencyUrl = "https://www.cbr-xml-daily.ru/daily_json.js";

        public async Task<Currency[]> GetParsed()
        {
            var json = new WebClient().DownloadString(CurrencyUrl);

            JObject obj = JObject.Parse(json);

            IList<JToken> results = obj["Valute"].Children().Children().ToList();

            IList<Currency> searchResults = new List<Currency>();

            foreach (JToken result in results)
            {
                Currency searchResult = result.ToObject<Currency>();

                searchResults.Add(searchResult with { DateUpdate = DateTime.Now });
            }

            return searchResults.ToArray();
        }
    }
}
