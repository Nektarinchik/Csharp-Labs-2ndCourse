using System;
using System.Collections.Generic;
using System.Linq;

namespace _053506_Ermolaev_Lab7
{
    class Company
    {
        public delegate void ChangeClients(string name, string surname);

        public delegate void ChangeRates(string name, string surname, string rate);

        public delegate void NewOrder(string name, string surname, int kilograms);

        public event ChangeClients OnChangeClients
        {
            add
            {
                _onChangeClients += value;
                JournalOfEvents.AddEvent("OnChangeClients", value.Method.Name);
            }
            remove
            {
                _onChangeClients -= value;
                JournalOfEvents.RemoveEvent("OnChangeClients", value.Method.Name);
            }
        }

        public event ChangeRates OnChangeRate
        {
            add
            {
                _onChangeRate += value;
                JournalOfEvents.AddEvent("OnChangeRate", value.Method.Name);
            }
            remove
            {
                _onChangeRate -= value;
                JournalOfEvents.RemoveEvent("OnChangeRate", value.Method.Name);
            }
        }

        public event NewOrder OnNewOrder
        {
            add
            {
                _onNewOrder += value;
                JournalOfEvents.AddEvent("OnNewOrder", value.Method.Name);
            }
            remove
            {
                _onNewOrder -= value;
                JournalOfEvents.RemoveEvent("OnNewOrder", value.Method.Name);
            }
        }
        public Journal JournalOfEvents { get; set; }
        public void Order(string name, string surname, int kilograms)
        {
            _onNewOrder(name, surname, kilograms);
            Client cl = _clients.Find(cl => cl.Name == name && cl.Surname == surname);
            if (cl == null)
            {
                cl = new Client(name, surname);
                _clients.Add(cl);
                _onChangeClients?.Invoke(cl.Name, cl.Surname);
            }
            if (kilograms < 1000)
            {
                bool isChange = false;
                if (cl.Rate == Rates.PROFITABLY || cl.Rate == Rates.NONE)
                    isChange = true;
                cl.Rate = Rates.EVERYDAY;
                double sum = _pricePerKG * kilograms * (1 - _discountForEverydayRate);
                cl.AddNewOrder(new Order(kilograms, "Everyday", Convert.ToInt32(_discountForEverydayRate * 100), sum));
                cl.SumWithEveryday += sum;
                cl.Sum += sum;
                if (isChange)
                    _onChangeRate?.Invoke(cl.Name, cl.Surname, "Everyday");
            }
            else
            {
                bool isChange = false;
                if (cl.Rate == Rates.EVERYDAY || cl.Rate == Rates.NONE)
                    isChange = true;
                double sum = _pricePerKG * kilograms * (1 - _discountForProfitablyRate);
                cl.Rate = Rates.PROFITABLY;
                cl.AddNewOrder(new Order(kilograms, "Profitably", Convert.ToInt32(_discountForProfitablyRate * 100), sum));
                cl.SumWithProfitably += sum;
                cl.Sum += sum;
                if (isChange)
                    _onChangeRate?.Invoke(cl.Name, cl.Surname, "Profitably");
            }
        }
        public void GetTotalSum () => Console.WriteLine($"Total sum is {TotalSum}$");

        public Client GetMostCostClient()
        {
            Client cl = _clients.OrderByDescending(t => t.Sum).First();
            return cl;
        }

        public int GetCountOfMostCostClients(double sum)
        {
            return _clients.Aggregate(0, (a, client) => a += client.Sum > sum ? 1 : 0);

            //return (from cl in _clients 
             //       where cl.Sum >= sum 
             //       select cl).Count();
        }
        public double TotalSum
        {
            get
            {
                _totalSum = 0;
                for (int i = 0; i < _clients.Count; ++i)
                    _totalSum += _clients[i].Sum;
                return _totalSum;
            }
        }
        public void PrintClientsTotalSum()
        {
            for(int i = 0; i < _clients.Count; ++i)
            {
                _clients[i].GetInfoAboutOrders();
            }
        }
        public void GetCostsListOfClients()
        {
            foreach(var cl in _clients)
            {
                Console.WriteLine("________________________________________________________________");
                var ordersWithEveryday = cl.GetEverydayOrders();
                Console.WriteLine($"{cl.Name} {cl.Surname} made the following orders at the Everyday rate:");
                foreach (var or in ordersWithEveryday) 
                {
                    Console.WriteLine($"{or.Name} kilograms - {or.Sum}$");
                }
                var ordersWithProfitably = cl.GetProfitablyOrders();
                Console.WriteLine($"{cl.Name} {cl.Surname} made the following orders at the Profitably rate:");
                foreach (var or in ordersWithProfitably)
                {
                    Console.WriteLine($"{or.Kilograms} kilograms - {or.Sum}$");
                }
                Console.WriteLine("________________________________________________________________");
            }
        }
        public IEnumerable<KeyValuePair<string, int>> GetRates()
        {
            return _rates.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        private event ChangeClients _onChangeClients;

        private event ChangeRates _onChangeRate;

        private event NewOrder _onNewOrder;

        private double _discountForEverydayRate = 0.05;

        private double _discountForProfitablyRate = 0.1;

        private double _pricePerKG = 0.5;

        private double _totalSum = 0;

        private Dictionary<string, int> _rates = new Dictionary<string, int>
        {
            {"Everyday", 5 },
            {"Profitably", 10 }
        };

        private List<Client> _clients = new List<Client>();
    }
}
