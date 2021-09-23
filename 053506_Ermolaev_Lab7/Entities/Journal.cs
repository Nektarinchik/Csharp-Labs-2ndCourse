using System;
using System.Collections.Generic;

namespace _053506_Ermolaev_Lab7
{
    class Journal
    {
        struct RegisteredEvent
        {
            public RegisteredEvent(string name, string description)
            {
                Name = name;
                Description = description;
            }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public void AddEvent(string name, string description)
        {
            _registeredEvents.Add(new RegisteredEvent(name, description));
        }

        public void RemoveEvent(string name, string description)
        {
            try
            {
                _registeredEvents.Remove(new RegisteredEvent(name, description));
            }
            catch (RemoveException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InfAboutNewClient(string name,string surname)
        {
            Console.WriteLine($"{name} {surname} our new client!");
        }

        public void InfAboutNewRate(string name, string surname, string rate)
        {
            Console.WriteLine($"Client {name} {surname} changed the rate to {rate}");
        }
        public void PrintEvents()
        {
            for(int i = 0; i < _registeredEvents.Count; ++i)
            {
                Console.WriteLine($"\nOn event {_registeredEvents[i].Name} subscribed method {_registeredEvents[i].Description}");
            }
        }

        private List<RegisteredEvent> _registeredEvents = new List<RegisteredEvent>();
    }
}




