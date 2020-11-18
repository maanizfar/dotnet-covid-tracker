using System;
using System.Text.Json.Serialization;

namespace CovidTracker.Models
{
    public class CountryStats
    {
        [JsonPropertyName("Country")]
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Slug { get; set; }
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        [JsonPropertyName("Date")]
        public DateTime UpdateTimeUtc { get; set; }
        public DateTime UpdateTime => UpdateTimeUtc.ToLocalTime();
    }
}
