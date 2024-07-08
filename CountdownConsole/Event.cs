using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestCountdownConsole")]

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

        [JsonIgnore]
        public int DaysRemaining
        {
            get {
                return (EndDate.Date - DateTime.Today).Days;
            }
        }
    }
}
