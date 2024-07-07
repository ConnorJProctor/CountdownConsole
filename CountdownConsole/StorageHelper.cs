using System.Text.Json;
using CountdownConsole;

internal static class StorageHelper
{

    public static List<Event> LoadEventsFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Event>>(jsonString) ?? new List<Event>();
        }
        return new List<Event>();
    }
    public static void SaveEventsToFile(List<Event> events, string filePath)
    {
        string jsonString = JsonSerializer.Serialize(events);
        File.WriteAllText(filePath, jsonString);
    }
}