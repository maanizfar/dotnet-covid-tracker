using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace CovidTracker.Models
{
    public class DataSummary
    {
        public string Message { get; set; }
        public GlobalStats Global { get; set; }

        public List<CountryStats> Countries { get; set; }

        [JsonPropertyName("Date")]
        public DateTime UpdateDateUtc { get; set; }
        public DateTime UpdateDate => UpdateDateUtc.ToLocalTime();
    }
}
