using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownConsole
{
    internal class Event
    {
        // Private field for ID
        private readonly Guid _id;

        // Constructor to initialize ID
        public Event()
        {
            _id = Guid.NewGuid();
        }

        // Property to get ID
        public Guid ID
        {
            get { return _id; }
        }

        // Property to get and set Title
        public string Title { get; set; }

        // Property to get and set EndDate
        public DateTime EndDate { get; set; }
    }
}
