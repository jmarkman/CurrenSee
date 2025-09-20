namespace CurrenSee.Network
{
    public class CurrenSeeHttp(string apiKey)
    {
        private const string BaseUrl = "https://api.fxratesapi.com/";
        private readonly HttpClient httpClient = CreateHttpClient();
        public string ApiKey => apiKey;

        public async Task<string> GetAsync(string url)
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private static HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };

            return httpClient;
        }
    }
}
