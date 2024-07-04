using CountdownConsole;
using ConsoleTables;

Console.WriteLine("Welcome to the Countdown Console!\n");

List<Event> existingEvents = new List<Event>();
Boolean exitApp = false;

while (!exitApp)
{
    Console.WriteLine("What would you like to do?\n" +
        $"E - View Existing Events\n" +
        $"N - Add a New Event\n" +
        $"R - Remove an Existing Event\n" +
        $"Q - Quit Application");

    string userChoice = Console.ReadLine().ToUpper();

    switch (userChoice)
    {
        case "E":
            Console.WriteLine("\nYou've chosen to view existing events.\n");

            ConsoleTable table = new ConsoleTable("ID", "Title", "End Date", "Days Remaining");
            foreach (Event e in existingEvents)
            {
                table.AddRow(e.ID,e.Title,e.EndDate,e.DaysRemaining);
            }

            table.Write();

            break;


        case "N":
            Console.WriteLine("\nYou've chosen to add a new event.\n");

            Console.WriteLine("Please enter the title of the new event: ");
            string newTitle = Console.ReadLine();

            Console.WriteLine("\nPlease enter the end date of the new event: ");
            string newDateInput = Console.ReadLine();
            DateTime newEndDate = DateTime.Parse(newDateInput);

            Console.WriteLine($"\nAdding the below event:\n" +
                $"Title: {newTitle}\n" +
                $"Date: {newEndDate}\n" +
                $"Confirm? (y/n)");

            string confirmNewEvent = Console.ReadLine();

            // Calculate the new ID
            int newId;
            if (!existingEvents.Any())
            {
                newId = 1;
            }
            else
            {
                newId = existingEvents.Max(e => e.ID) + 1;
            }

            Event newEvent = new Event();
            newEvent.ID             = newId;
            newEvent.Title          = newTitle;
            newEvent.EndDate        = newEndDate;

            existingEvents.Add(newEvent);
            Console.WriteLine($"Added event '{newEvent.Title}' successfully!");

            break;

        case "R":
            Console.WriteLine("\nYou've chosen to remove an existing event.\n");


            Console.WriteLine("Please enter the ID of the event you would like to remove: ");
            int idToRemove = Convert.ToInt32(Console.ReadLine());

            Event selectedEvent = existingEvents.FirstOrDefault(e => e.ID == idToRemove);

            if (selectedEvent != null)
            {
                existingEvents.Remove(selectedEvent);
                Console.WriteLine($"Removed event '{selectedEvent.Title}' successfully!");
            }
            else
            {
                Console.WriteLine($"Could not find an event with ID {idToRemove}");

            }
            break;


        case "Q":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Your choice selection was invalid.");
            break;
    }

    Console.WriteLine();

}