using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace CurrenSee.CommandLine
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();

            var apiKey = config.GetSection("Settings")["fxRatesApiKey"];

            var currenSeeClient = new CurrenSeeClient(apiKey);

            Console.WriteLine("Getting all global currencies...");
            Console.WriteLine();
            var currencies = await currenSeeClient.Currencies.GetAsync();

            Console.WriteLine($"The currency list '{nameof(currencies)}' has {currencies.Count()} items");
            Console.WriteLine();
            Console.WriteLine("Let's get the metadata for the Euro");
            Console.WriteLine();

            var euro = currencies.First(c => c.Code == "EUR");

            Console.WriteLine(euro.ToString());
            
            Console.WriteLine("Now let's convert some US dollars into various currency");
            Console.WriteLine();
            var latestExchangeRates = await currenSeeClient.LatestExchangeRates.GetAsync("USD", ["EUR", "GBP", "JPY", "AUD", "CAD"]);
            Console.WriteLine(latestExchangeRates.ToString());

        }
    }
}
