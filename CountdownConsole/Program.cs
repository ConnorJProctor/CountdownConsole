using CountdownConsole;
using ConsoleTables;

Console.WriteLine("Welcome to the Countdown Console!\n");

List<Event> existingEvents = new List<Event>();
Boolean exitApp = false;

while (!exitApp)
{
    Console.WriteLine("What would you like to do?\n" +
        $"0 - View Existing Events\n" +
        $"1 - Add a New Event");

    string userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "0":
            Console.WriteLine("\nYou've chosen to view existing events.\n");

            ConsoleTable table = new ConsoleTable("ID", "Title", "End Date");
            foreach (Event e in existingEvents)
            {
                table.AddRow(e.ID,e.Title,e.EndDate);
            }

            table.Write();

            break;


        case "1":
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
            newEvent.ID = newId;
            newEvent.Title = newTitle;
            newEvent.EndDate = newEndDate;

            existingEvents.Add(newEvent);

            break;

        default:
            Console.WriteLine("Your choice selection was invalid.");
            break;
    }

    Console.ReadLine();

}