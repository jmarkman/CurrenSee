using CurrenSee.Models;
using CurrenSee.Network;
using System.Text.Json;

namespace CurrenSee.Endpoints.LatestExchangeRate
{
    public class LatestExchangeRateEndpoint(CurrenSeeHttp currenseeHttp) : ILatestExchangeRateEndpoint
    {
        private const string LatestExchangeRatesUrl = "latest";

        /// <inheritdoc />
        public async Task<LatestExchangeRates> GetAsync(string? baseCurrency = null, IEnumerable<string>? quoteCurrencies = null)
        {
            var urlParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(baseCurrency))
            {
                urlParams.Add($"base={baseCurrency}");
            }

            if (quoteCurrencies is not null && quoteCurrencies.Any())
            {
                urlParams.Add($"currencies={string.Join(",", quoteCurrencies)}");
            }

            var queryUrl = BuildUrl(urlParams);

            var response = await currenseeHttp.GetAsync(queryUrl);
            return JsonSerializer.Deserialize<LatestExchangeRates>(response)!;
        }

        private string BuildUrl(List<string> urlParams)
        {
            if (urlParams.Count == 0)
            {
                return LatestExchangeRatesUrl;
            }

            return $"{LatestExchangeRatesUrl}?api_key={currenseeHttp.ApiKey}&{string.Join("&", urlParams)}";
        }
    }
}
