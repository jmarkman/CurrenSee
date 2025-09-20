using CurrenSee.Endpoints;
using CurrenSee.Endpoints.Currencies;
using CurrenSee.Endpoints.LatestExchangeRate;
using CurrenSee.Network;

namespace CurrenSee
{
    public class CurrenSeeClient : ICurrenSeeClient
    {
        public ICurrenciesEndpoint Currencies { get; }

        public ILatestExchangeRateEndpoint LatestExchangeRates { get; }

        public CurrenSeeClient(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("API key must be provided", nameof(apiKey));
            }

            var currenseeHttp = new CurrenSeeHttp(apiKey);

            Currencies = new CurrenciesEndpoint(currenseeHttp);
            LatestExchangeRates = new LatestExchangeRateEndpoint(currenseeHttp);
        }
    }
}
