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

        public int ID {  get; set; }
        public string Title { get; set; }
        public DateTime EndDate { get; set; }
        public int DaysRemaining
        {
            get {
                return (EndDate.Date - DateTime.Today).Days;
            }
        }
    }
}
