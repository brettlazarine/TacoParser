using System;
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
            //DONE -- TODO:  Find the two Taco Bells that are the furthest from one another.
            //DONE -- HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            //DONE -- use File.ReadAllLines(path) to grab all the lines from your csv file
            //DONE -- Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0) { logger.LogError("File is empty."); }
            if (lines.Length == 1) { logger.LogWarning("File has only one line."); }

            logger.LogInfo($"Lines: {lines[0]}");

            //DONE -- Create a new instance of your TacoParser class
            var parser = new TacoParser();

            //DONE -- Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            //DONE -- DON'T FORGET TO LOG YOUR STEPS

            //DONE -- Now that your Parse method is completed, START BELOW ----------

            //DONE -- TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            ITrackable tacoOne = null;
            ITrackable tacoTwo = null;
            //DONE -- Create a `double` variable to store the distance
            double distance = 0;

            //DONE -- Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //DONE -- HINT NESTED LOOPS SECTION---------------------
            //DONE -- Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];

                //DONE -- Create a new corA Coordinate with your locA's lat and long
                var corA = new GeoCoordinate() { Latitude = locA.Location.Latitude, Longitude = locA.Location.Longitude };

                //DONE -- Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];

                    //DONE -- Create a new Coordinate with your locB's lat and long
                    var corB = new GeoCoordinate() { Latitude = locB.Location.Latitude, Longitude = locB.Location.Longitude };

                    //DONE -- Now, compare the two using `.GetDistanceTo()`, which returns a double
                    //DONE -- If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoOne = locA;
                        tacoTwo = locB;
                    }
                }

            }

            //DONE -- Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            logger.LogInfo($"{tacoOne.Name} and {tacoTwo.Name} are the farthest away from each other.");
        }
    }
}
