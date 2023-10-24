using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingKata
{
    // You'll need to create a TacoBell class 
    // that conforms to ITrackable - DONE
    public class TacoBell : ITrackable
    {
        public TacoBell()
        {
        }

        public TacoBell(string name, Point location)
        {
            Name = name;
            Location = location;

        }

        public string Name { get; set; }
        public Point Location { get; set; }
    }
}
