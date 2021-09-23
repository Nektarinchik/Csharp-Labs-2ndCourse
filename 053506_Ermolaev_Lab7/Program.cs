using System;

namespace _053506_Ermolaev_Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Subscribes methods to events

            Journal journal = new Journal();
            Company IEErmolaev = new Company
            {
                JournalOfEvents = journal
            };


            IEErmolaev.OnChangeClients += IEErmolaev.JournalOfEvents.InfAboutNewClient;
            IEErmolaev.OnChangeRate += IEErmolaev.JournalOfEvents.InfAboutNewRate;


            IEErmolaev.OnNewOrder += (name, surname, kg) =>
            {
                Console.WriteLine($"{name} {surname} wants to transport {kg} kilograms");
            };


            IEErmolaev.Order("Nikita", "Ermolaev", 980);
            IEErmolaev.Order("Client", "Two", 1500);
            IEErmolaev.Order("Client", "Three", 300);
            IEErmolaev.Order("Nikita", "Ermolaev", 100);
            IEErmolaev.Order("Client", "Four", 1292);
            IEErmolaev.Order("Client", "Five", 180);
            IEErmolaev.Order("Client", "Six", 891);
            IEErmolaev.Order("Client", "Two", 280);
            IEErmolaev.Order("Client", "Two", 951);



            Console.WriteLine();

            // Testing the list of rates
            var rates = IEErmolaev.GetRates();
            foreach(var item in rates)
            {
                Console.WriteLine($"Rate: {item.Key} - with discount {item.Value}%");
            }

            Console.WriteLine();

            // Testing the getting of the total cost
            IEErmolaev.GetTotalSum();

            Console.WriteLine();

            // Testing the getting of the total sum an individual client at rates
            IEErmolaev.PrintClientsTotalSum();

            Console.WriteLine();

            // Testing the getting of the most paid client
            var cl = IEErmolaev.GetMostCostClient();
            Console.WriteLine($"The max cost paid by {cl.Name} {cl.Surname} is {cl.Sum}$");

            Console.WriteLine();

            // Testing the getting of the list of clients who paid more rhan certain cost 
            Console.WriteLine($"The number of clients who paid more than a certain cost - {IEErmolaev.GetCountOfMostCostClients(500.0)}.");

            Console.WriteLine();

            // Testing the getting of the list of costs for individual client
            IEErmolaev.GetCostsListOfClients();
        }
    }
}
