using System.Text;
using System.Text.Json.Serialization;

namespace CurrenSee.Models
{
    public class LatestExchangeRates
    {

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; } = string.Empty;

        [JsonPropertyName("rates")]
        public Dictionary<string, double> Rates { get; set; } = new();

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Date: {Date.ToLocalTime().ToString()}");
            sb.AppendLine($"Base Currency: {Base}");
            foreach (var rate in Rates)
            {
                sb.AppendLine($"{rate.Key}: {rate.Value}");
            }

            return sb.ToString();
        }
    }
}
