using NUnit.Framework.Internal.Execution;
using NUnit.Framework.Legacy;
using CountdownConsoleEvent = CountdownConsole.Event;

namespace TestCountdownConsole
{
    public class EventsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEventCreation()
        {
            var events = new List<CountdownConsoleEvent>();
            var newEvent = new CountdownConsoleEvent { ID = 1, Title = "Test Event", EndDate = DateTime.Today.AddDays(5) };
            events.Add(newEvent);
            ClassicAssert.IsTrue(events.Contains(newEvent));
            ClassicAssert.AreEqual(5, newEvent.DaysRemaining); // Assuming today's date is the reference
        }


        [Test]
        public void TestEventRemoval()
        {
            var events = new List<CountdownConsoleEvent> {
                new CountdownConsoleEvent { ID = 1, Title = "Test Event", EndDate = DateTime.Today.AddDays(5) }
            };
            var eventToRemove = events.First();
            events.Remove(eventToRemove);
            ClassicAssert.IsFalse(events.Contains(eventToRemove));
        }

        [Test]
        public void TestEventPersistence()
        {
            var events = new List<CountdownConsoleEvent> {
                new CountdownConsoleEvent { ID = 1, Title = "Test Event", EndDate = DateTime.Today.AddDays(5) }
            };
            string filePath = "test.json";
            StorageHelper.SaveEventsToFile(events, filePath);
            var loadedEvents = StorageHelper.LoadEventsFromFile(filePath);
            ClassicAssert.AreEqual(events.Count, loadedEvents.Count);
            ClassicAssert.AreEqual(events[0].Title, loadedEvents[0].Title);
            // Additional checks for Date and ID
        }



    }
}