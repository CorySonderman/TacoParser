﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            //logger.LogInfo("Log initialized"); ****Commented out for better run presentation

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            //logger.LogInfo($"Lines: {lines[0]}"); ****Commented out for better run presentation

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();
            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other. -DONE
           
            ITrackable closestTacoBell1 = new TacoBell();
            ITrackable closestTacoBell2 = new TacoBell();
            ITrackable furthestTacoBell1 = new TacoBell();
            ITrackable furthestTacoBell2 = new TacoBell();


            // Create a `double` variable to store the distance
            //double distance = 0;
            double closestDistance = double.MaxValue;
            double furthestDistance = double.MinValue;
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;` -DONE

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`) - DONE
            // Create a new corA Coordinate with your locA's lat and long - DONE
            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`) - DONE

            // Create a new Coordinate with your locB's lat and long - DONE

            // Now, compare the two using `.GetDistanceTo()`, which returns a double 
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above - DONE

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int h = 0; h < locations.Length; h++)
                {
                    if (i == h)
                    {
                        continue; // Skip comparing a location to itself
                    }

                    var locB = locations[h];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    double currentDistance = corA.GetDistanceTo(corB);

                    if (currentDistance < closestDistance)
                    {
                        closestDistance = currentDistance;
                        closestTacoBell1 = locA;
                        closestTacoBell2 = locB;
                    }

                    if (currentDistance > furthestDistance)
                    {
                        furthestDistance = currentDistance;
                        furthestTacoBell1 = locA;
                        furthestTacoBell2 = locB;
                    }
                }
            }

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other. - DONE
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("IT'S RAINING TACOS!");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{furthestTacoBell1.Name}");
            Console.ResetColor();
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{furthestTacoBell2.Name}");
            Console.ResetColor();
            Console.WriteLine($"have the farthest distance between them.");
            Console.WriteLine($"They are {Math.Round(furthestDistance / 1609.34)} miles apart.");
            Console.WriteLine();
            Console.WriteLine("But why drive all that way and waste your gas? ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{closestTacoBell1.Name}");
            Console.ResetColor();
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{closestTacoBell2.Name}");
            Console.ResetColor();
            
            Console.WriteLine($"have the closest distance between them.");
            Console.WriteLine($"They are {Math.Round(closestDistance / 1609.34)} miles apart.");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Can I get some hot sauce for my hot sauce?");
            Console.ResetColor();
            Console.WriteLine();
            // Extra bonus.  Maybe add another method to find the 2 closest taco bells or the
            // closest taco bell to each other
        }
    }
}
