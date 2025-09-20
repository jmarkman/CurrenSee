using CurrenSee.Models;

namespace CurrenSee.Endpoints.LatestExchangeRate
{
    public interface ILatestExchangeRateEndpoint
    {
        /// <summary>
        /// Retrieves the latest exchange rates.
        /// </summary>
        /// <param name="baseCurrency">The ISO currency code that represents what currency we have</param>
        /// <param name="quoteCurrencies">The ISO currency codes that represent the currencies we'd like to exchange for</param>
        Task<LatestExchangeRates> GetAsync(string? baseCurrency = null, IEnumerable<string>? quoteCurrencies = null);
    }
}
