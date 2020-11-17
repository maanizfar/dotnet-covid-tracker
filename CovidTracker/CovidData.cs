using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace CovidTracker
{
    public class CovidData
    {
        public string Message { get; set; }
        public GlobalStats Global { get; set; }

        public List<Country> Countries { get; set; }

        [JsonPropertyName("Date")]
        public DateTime UpdateDateUtc { get; set; }
        public DateTime UpdateDate => UpdateDateUtc.ToLocalTime();
    }

    public class GlobalStats
    {
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
    }

    public class Country
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
