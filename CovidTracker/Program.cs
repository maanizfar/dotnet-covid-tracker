using System;
using System.Threading.Tasks;
using System.Net.Http;
using CovidTracker.Api;

namespace CovidTracker
{
    class Program
    {
        static async Task Main(string[] args)
        {

            CovidApi api = new CovidApi(new HttpClient());

            Console.Write("Fetching data...\n");

            StatsPrinter printer = new StatsPrinter(await api.GetSummary());

            while(true)
            {
                ConsoleKeyInfo choice;
                do
                {
                    Console.WriteLine("\n-------- COVID-19 Tracker --------");
                    Console.WriteLine("\n1. Show Global Stats");
                    Console.WriteLine("2. Show Countries Stats");
                    Console.WriteLine("3. Exit\n");
                    Console.Write("Choose an option: ");
                    choice = Console.ReadKey();
                    Console.WriteLine();
                }
                while (choice.KeyChar != '1' && choice.KeyChar != '2' && choice.KeyChar != '3');

                switch (choice.KeyChar)
                {
                    case '1':
                        printer.PrintGlobalStats();
                        break;

                    case '2':
                        printer.PrintCountriesStats();
                        break;

                    case '3':
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }


    }
}
