using CountdownConsole;
using ConsoleTables;

// 
string filePath = "events.json";
List<Event> existingEvents = StorageHelper.LoadEventsFromFile(filePath)
    .OrderBy(e => e.EndDate)
    .ToList();

Console.WriteLine("Welcome to the Countdown Console!\n");

Boolean exitApp = false;
while (!exitApp)
{
    Console.WriteLine("What would you like to do?\n" +
        $"E - View Existing Events\n" +
        $"N - Add a New Event\n" +
        $"U - Update an Existing Event\n" +
        $"R - Remove an Existing Event\n" +
        $"Q - Save Changes & Quit Application");

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

            string confirmNewEvent = Console.ReadLine().ToUpper();

            // Calculate the new ID

            if (confirmNewEvent == "Y")
            {
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
                Console.WriteLine($"Added event '{newEvent.Title}' successfully!");

            }


            break;


        case "U":
            Console.WriteLine("\nYou've chosen to update an existing event.\n");

            Console.WriteLine("Please enter the ID of the event you would like to update: ");
            int idToUpdate = Convert.ToInt32(Console.ReadLine());

            Event eventToUpdate = existingEvents.FirstOrDefault(e => e.ID == idToUpdate);

            if (eventToUpdate != null)
            {

                Console.WriteLine($"Please enter the new title or leave blank to keep {eventToUpdate.Title}: ");
                string updatedTitle = Console.ReadLine();
                if (updatedTitle.Length < 1)
                {
                    updatedTitle = eventToUpdate.Title;
                }

                Console.WriteLine($"\nPlease enter new end date or leave blank to keep {eventToUpdate.EndDate}: ");
                string updatedDateInput = Console.ReadLine();

                DateTime updatedEndDate;
                if (updatedDateInput.Length < 1)
                {
                    updatedEndDate = eventToUpdate.EndDate;
                }
                else
                {
                    updatedEndDate = DateTime.Parse(updatedDateInput);
                }


                Console.WriteLine($"\nUpdating event details from:\n" +
                    $"Title: {eventToUpdate.Title}\n" +
                    $"Date: {eventToUpdate.EndDate}\n");

                Console.WriteLine($"\nUpdating event details to:\n" +
                    $"Title: {updatedTitle}\n" +
                    $"Date: {updatedEndDate}\n" +
                    $"Confirm? (y/n)");

                string confirmUpdateEvent = Console.ReadLine().ToUpper();

                if (confirmUpdateEvent == "Y")
                {
                    eventToUpdate.Title = updatedTitle;
                    eventToUpdate.EndDate = updatedEndDate;

                    Console.WriteLine($"Updated event '{eventToUpdate.Title}' successfully!");

                }


            }
            else
            {
                Console.WriteLine($"Could not find an event with ID {idToUpdate}");

            }


            break;


        case "R":
            Console.WriteLine("\nYou've chosen to remove an existing event.\n");


            Console.WriteLine("Please enter the ID of the event you would like to remove: ");
            int idToRemove = Convert.ToInt32(Console.ReadLine());

            Event eventToRemove = existingEvents.FirstOrDefault(e => e.ID == idToRemove);

            if (eventToRemove != null)
            {
                existingEvents.Remove(eventToRemove);
                Console.WriteLine($"Removed event '{eventToRemove.Title}' successfully!");
            }
            else
            {
                Console.WriteLine($"Could not find an event with ID {idToRemove}");

            }
            break;


        case "Q":
            StorageHelper.SaveEventsToFile(existingEvents, filePath);
            Console.WriteLine("Events saved. Exiting application.");
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Your choice selection was invalid.");
            break;
    }

    Console.WriteLine();

}