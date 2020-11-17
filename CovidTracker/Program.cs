using System;
using System.Threading.Tasks;
using System.Net.Http;
using CovidTracker.Api;
using ConsoleTables;

namespace CovidTracker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CovidApi api = new CovidApi(new HttpClient());

            ConsoleKeyInfo choice;
            do
            {
                Console.WriteLine("\n1. Global");
                Console.WriteLine("2. Countries");
                Console.Write("Choose an option: ");
                choice = Console.ReadKey();
                Console.WriteLine();
            }
            while (choice.KeyChar != '1' && choice.KeyChar != '2');

            if(choice.KeyChar == '1')
            {
                var data = await api.GetGlobalStats();
                if(data != null)
                {
                    var table = new ConsoleTable("Total Confirmed", "Total Deaths", "Total Recovered");
                    table.AddRow(data.TotalConfirmed, data.TotalDeaths, data.TotalRecovered);
                    Console.WriteLine();
                    table.Write(Format.Alternative);

                    var table2 = new ConsoleTable("New Confirmed", "New Deaths", "New Recovered");
                    table2.AddRow(data.NewConfirmed, data.NewDeaths, data.NewRecovered);
                    Console.WriteLine();
                    table2.Write(Format.Alternative);
                }
                else
                {
                    Console.WriteLine("Data not available");
                }
            }
            else if(choice.KeyChar == '2')
            {
                var data = await api.GetCountriesStats();

                if (data != null)
                {
                    var table = new ConsoleTable("Country", "Total Confirmed", "Total Deaths", "Total Recovered");
         
                    foreach(var country in data)
                    {
                        table.AddRow(country.Name, country.TotalConfirmed, country.TotalDeaths, country.TotalRecovered);
                        Console.WriteLine();
                    }
                    table.Write(Format.Alternative);
                }
                else
                {
                    Console.WriteLine("Data not available");
                }
            }
        }
    }
}
