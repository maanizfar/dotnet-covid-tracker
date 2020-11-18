using ConsoleTables;
using CovidTracker.ExtensionMethods;
using CovidTracker.Models;
using System;
using System.Collections.Generic;

namespace CovidTracker
{
    class StatsPrinter
    {
        public DataSummary Data { get; set; }

        public StatsPrinter(DataSummary data)
        {
            this.Data = data;
        }

        public void PrintGlobalStats()
        {
            if (Data == null)
            {
                Console.WriteLine("Data not available. Check network availability.");
                return;
            }

            GlobalStats data = Data.Global;

            ConsoleTable table = new ConsoleTable("Total Confirmed", "Total Deaths", "Total Recovered");
            table.AddRow(data.TotalConfirmed.CommaSeparated(), data.TotalDeaths.CommaSeparated(), data.TotalRecovered.CommaSeparated());

            ConsoleTable table2 = new ConsoleTable("New Confirmed", "New Deaths", "New Recovered");
            table2.AddRow(data.NewConfirmed.CommaSeparated(), data.NewDeaths.CommaSeparated(), data.NewRecovered.CommaSeparated());
            
            Console.WriteLine();
            Console.WriteLine("----------- Global Covid-19 Stats -----------");
            Console.WriteLine();
            table.Write(Format.Alternative);
            table2.Write(Format.Alternative);
            Console.WriteLine("Updated: {0}\n", Data.UpdateDate);

        }

        public void PrintCountriesStats()
        {
            if(Data == null)
            {
                Console.WriteLine("Data not available. Check network availability.");
                return;
            }

            List<CountryStats> data =  Data.Countries;

            ConsoleTable table = new ConsoleTable("Country",
                        "New Confirmed", "New Deaths", "New Recovered",
                        "Total Confirmed", "Total Deaths", "Total Recovered");

            foreach (CountryStats country in data)
            {
                table.AddRow(country.Name, country.NewConfirmed.CommaSeparated(), country.NewDeaths.CommaSeparated(),
                    country.NewRecovered.CommaSeparated(), country.TotalConfirmed.CommaSeparated(), country.TotalDeaths.CommaSeparated(),
                    country.TotalRecovered.CommaSeparated());
            }

            Console.WriteLine();
            Console.WriteLine("\t\t\t\t----------- Country-Wise Covid-19 Stats -----------");
            Console.WriteLine();
            table.Write(Format.Alternative);
            Console.WriteLine("Updated: {0}\n", Data.UpdateDate);
        }

    }
}
