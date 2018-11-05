using SWTP.BL;
using SWTP.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsTravelPlanner_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            IStarShipBL _ssBL = new StarShipBL();

            Console.WriteLine("Welcome to Star Wars Travel Planner!");
            Console.WriteLine("");

            bool isRun = true;
            bool validDistance = false;
            string sDistance = string.Empty;
            long nDistance = -1;
            double dDistance = -1;

            while (isRun)
            {
                while (!validDistance)
                {
                    WaitForDistance(ref validDistance, out sDistance, out nDistance, ref dDistance);
                    Console.WriteLine("");

                    if (!validDistance)
                    {
                        Console.WriteLine("Type E to exit application");
                    }
                }

                var stopList = _ssBL.GetAllStops(nDistance);

                DisplayResults(stopList);

                Console.WriteLine("Type Y to enter another distance or any another key to exit Application");
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    isRun = false;
                }

                validDistance = false;
            }
        }

        private static void DisplayResults(IEnumerable<StarShipStopDto> stopList)
        {
            StringBuilder sbAvailable = new StringBuilder();
            StringBuilder sbNotAvailable = new StringBuilder();
            foreach (var item in stopList)
            {
                if (item != null)
                {
                    if (item.Stops >= 0)
                    {
                        //sbAvailable.AppendLine($"{item.Name}: {(item.Stops == 0 ? "No stop needed" : item.Stops.ToString())}");
                        sbAvailable.AppendLine($"{item.Name}: {item.Stops}");
                    }
                    else
                    {
                        sbNotAvailable.AppendLine($"{item.Name}");
                    }
                }
            }

            Console.WriteLine("Results:");
            Console.WriteLine("");

            Console.WriteLine("Available StarShips: Stops");
            Console.WriteLine(sbAvailable.ToString());

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Starships with unavailable information:");
            Console.WriteLine("");
            Console.WriteLine(sbNotAvailable.ToString());

            Console.WriteLine("");
        }

        private static void WaitForDistance(ref bool validDistance, out string sDistance, out long nDistance, ref double dDistance)
        {
            Console.WriteLine("Please, enter the distance you need to cover:");
            sDistance = Console.ReadLine();

            if (sDistance.ToUpper() == "E")
            {
                Environment.Exit(0);
            }
            Console.WriteLine("");
            Console.WriteLine("Processing information...");


            if (long.TryParse(sDistance, out nDistance))
            {
                if (nDistance < 0)
                {
                    Console.WriteLine("You are already there!");
                }
                else
                {
                    validDistance = true;
                }
            }
            else
            {
                if (double.TryParse(sDistance, out dDistance))
                {
                    nDistance = Convert.ToInt64(Math.Truncate(dDistance));
                    validDistance = true;
                }
                else
                {
                    Console.WriteLine("I am sorry. Only numbers are accepted.");
                }
            }
        }
    }
}
