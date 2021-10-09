using System;

namespace _053506_Ermolaev_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            Company IEErmolaev = new Company
            {
                JournalOfEvents = journal
            };


            IEErmolaev.OnChangeClients += journal.InfAboutNewClient;
            IEErmolaev.OnChangeRate += journal.InfAboutNewRate;


            IEErmolaev.OnNewOrder += (name, surname, kg) =>
            {
                Console.WriteLine($"{name} {surname} wants to transport {kg} kilograms");
            };


            IEErmolaev.Order("Nikita", "Ermolaev", 980);
            IEErmolaev.Order("Client", "Two", 1500);
            IEErmolaev.Order("Client", "Three", 300);
            IEErmolaev.Order("Nikita", "Ermolaev", 2500);
            IEErmolaev.PrintClients();

            journal.PrintEvents();
        }
    }
}
