using CurrenSee.Models;

namespace CurrenSee.Endpoints.Currencies
{
    public interface ICurrenciesEndpoint
    {
        /// <summary>
        /// Retrieves a list of available currencies and their metadata.
        /// </summary>
        Task<IEnumerable<Currency>> GetAsync();
    }
}
