using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SWTP.Application.Interfaces;
using System;
using System.Text;

namespace SWTPCli
{
    class Program
    {
        private readonly StarShipService starShipService;
        private readonly IStarShipApplication _starShipApplication;
        private static readonly IStarShipApplication _starShipApplication1;
        public Program(IStarShipApplication starShipApplication)
        {
            _starShipApplication = starShipApplication;
            starShipService = new StarShipService(_starShipApplication);
        }

        static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            Console.WriteLine("Welcome to Star Wars Travel Planner!");
            Console.WriteLine("");

            bool validDistance = false;
            string sDistance = string.Empty;
            long nDistance = -1;

            while (!validDistance)
            {
                Console.WriteLine("Please, enter the distance you need to cover:");
                sDistance = Console.ReadLine();

                if (long.TryParse(sDistance, out nDistance))
                {
                    if (nDistance < 0)
                        Console.WriteLine("You are already there!");
                    else
                        validDistance = true;
                }
            }


            var program = new Program(_starShipApplication1);
            var getAll = program._starShipApplication.GetAllStops(nDistance);

            StringBuilder sb = new StringBuilder();
            foreach (var item in getAll)
            {
                sb.AppendLine($"{item.Name}: {(item.Stops < 0 ? item.Message : item.Stops.ToString())}");
            }

            Console.WriteLine("Here are the requested information");
            Console.WriteLine(sb.ToString());

            Console.WriteLine();
            Console.WriteLine("Please press any key to exit application");
            Console.ReadLine();
        }

        public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .Build();
    }
}

