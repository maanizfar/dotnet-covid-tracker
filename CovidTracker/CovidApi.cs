using static System.Console;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using CovidTracker.Models;
//using System.Text.Json;

namespace CovidTracker.Api
{
    public class CovidApi
    {
        private string uri = "https://api.covid19api.com/summary";
        private readonly HttpClient _client;

        public CovidApi(HttpClient client)
        {
            this._client = client;
        }

        public async Task<DataSummary> GetSummary()
        {
            try
            {
                //var streamTask = _client.GetStreamAsync(uri);
                //Summary summary = await JsonSerializer.DeserializeAsync<Summary>(await streamTask);
                DataSummary summary = await _client.GetFromJsonAsync<DataSummary>(uri);

                return summary;
            }
            catch(HttpRequestException e)
            {
                WriteLine("Error: {0}", e.Message);
            }

            return null;
        }

        public async Task<GlobalStats> GetGlobalStats()
        {
            DataSummary summary = await GetSummary();

            return summary.Global;
        }

        public async Task<List<CountryStats>> GetCountriesStats()
        {
            DataSummary summary = await GetSummary();

            return summary.Countries;
        }
    }
}
