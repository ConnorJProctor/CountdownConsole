using CountdownConsole;

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
            Console.WriteLine("You've chosen to view existing events.");
            break;

        case "1":
            Console.WriteLine("You've chosen to add a new event.");
            break;

        default:
            Console.WriteLine("Your choice selection was invalid.");
            break;
    }

    Console.ReadLine();

}