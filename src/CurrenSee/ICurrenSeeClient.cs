using CurrenSee.Endpoints.Currencies;
using CurrenSee.Endpoints.LatestExchangeRate;

namespace CurrenSee
{
    public interface ICurrenSeeClient
    {
        /// <summary>
        /// Endpoint for currency list
        /// </summary>
        ICurrenciesEndpoint Currencies { get; }

        /// <summary>
        /// Endpoint for exchange rates
        /// </summary>
        ILatestExchangeRateEndpoint LatestExchangeRates { get; }
    }
}
