using static System.Console;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task<CovidData> GetSummary()
        {
            try
            {
                var streamTask = _client.GetStreamAsync(uri);
                CovidData data = await JsonSerializer.DeserializeAsync<CovidData>(await streamTask);

                return data;
            }
            catch(HttpRequestException e)
            {
                WriteLine("\nException Caught!");
                WriteLine("Error message: {0}", e.Message);
            }

            return null;
        }

        public async Task<GlobalStats> GetGlobalStats()
        {
            CovidData data = await GetSummary();

            return data.Global;
        }

        public async Task<List<Country>> GetCountriesStats()
        {
            CovidData data = await GetSummary();

            return data.Countries;
        }
    }
}
