using CurrenSee.Models;
using CurrenSee.Network;
using System.Text.Json;

namespace CurrenSee.Endpoints
{
    public class CurrenciesEndpoint(CurrenSeeHttp currenseeHttp) : ICurrenciesEndpoint
    {
        /// <inheritdoc />
        public async Task<IEnumerable<Currency>> GetAsync()
        {
            var response = await currenseeHttp.GetAsync($"currencies?api_key={currenseeHttp.ApiKey}");
            var currencyDictionary = JsonSerializer.Deserialize<Dictionary<string, Currency>>(response);

            return currencyDictionary?.Values.ToList() ?? Enumerable.Empty<Currency>();
        }
    }
}
