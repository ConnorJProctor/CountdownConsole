using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownConsole
{
    internal class Event
    {

        // Constructor to initialize ID
        public Event()
        {
        }

        // Property to get and set ID
        public int ID {  get; set; }

        // Property to get and set Title
        public string Title { get; set; }

        // Property to get and set EndDate
        public DateTime EndDate { get; set; }
    }
}
