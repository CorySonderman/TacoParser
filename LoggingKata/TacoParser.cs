using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");  ****Commented out for better run presentation

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null - DONE
                logger.LogWarning("Something's wrong becuase the length is less than 3.  Please double check the data.");
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0 - done
            if (double.TryParse(cells[0], out double latitude) == false)
            {
                logger.LogError($" {cells[0]} I Wasn't able to parse latitude as a double.  Please double check the data.");
            }
            // grab the longitude from your array at index 1 - done
            if (double.TryParse(cells[1], out double longitude) == false)
            {
                logger.LogError($" {cells[1]} I Wasn't able to parse longitude as a double.  Please double check the data.");
            }



            // grab the name from your array at index 2 - Done
            var name = cells[2];

            if (cells[2] == null || cells[2].Length == 0)
            {
                logger.LogError("No location found");
            }

            // Your going to need to parse your string as a `double` 
            // which is similar to parsing a string as an `int` - Got it

            // You'll need to create a TacoBell class 
            // that conforms to ITrackable - DONE

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly - DONE
            var point = new Point
            {
                Latitude = latitude,
                Longitude = longitude
            };
            var tacoBell = new TacoBell();
            tacoBell.Location = point;
            tacoBell.Name = name;

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable - Done
            
            return tacoBell;
        }
    }
}