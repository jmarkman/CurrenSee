using System.Text;
using System.Text.Json.Serialization;

namespace CurrenSee.Models
{
    public class Currency
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("decimal_digits")]
        public int DecimalDigits { get; set; }

        [JsonPropertyName("name_plural")]
        public string NamePlural { get; set; } = string.Empty;

        [JsonPropertyName("rounding")]
        public int Rounding { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("symbol_native")]
        public string SymbolNative { get; set; } = string.Empty;

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Code: {Code}");
            sb.AppendLine($"Symbol: {Symbol}");
            sb.AppendLine($"Symbol Native: {SymbolNative}");
            sb.AppendLine($"Decimal Digits: {DecimalDigits}");
            sb.AppendLine($"Rounding: {Rounding}");
            sb.AppendLine($"Name Plural: {NamePlural}");

            return sb.ToString();
        }
    }
}
