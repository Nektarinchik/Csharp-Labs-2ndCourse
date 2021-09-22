using System;

namespace _053506_Ermolaev_Lab5
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
            Client cl = _clients.Find(new Client(name, surname));
            if (cl == null)
            {
                cl = new Client(name, surname);
                _onChangeClients?.Invoke(cl.Name, cl.Surname);
            }
            if (kilograms < 1000)
            {
                cl.Rate = Rates.EVERYDAY;
                cl.Sum = _pricePerKG * kilograms * (1 - _discountForEverydayRate);
                _onChangeRate?.Invoke(cl.Name, cl.Surname, "Everyday");
            }
            else
            {
                cl.Rate = Rates.PROFITABLY;
                cl.Sum = _pricePerKG * kilograms * (1 - _discountForProfitablyRate);
                _onChangeRate?.Invoke(cl.Name, cl.Surname, "Profitably");
            }
            _clients.Add(cl);
            Console.WriteLine($"Total sum - {TotalSum}");
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

        public void PrintClients()
        {
            for(int i = 0; i < _clients.Count; ++i)
            {
                Console.WriteLine($"{_clients[i].Name} {_clients[i].Surname}. Price: {_clients[i].Sum}");
            }
        }

        private event ChangeClients _onChangeClients;

        private event ChangeRates _onChangeRate;

        private event NewOrder _onNewOrder;

        private double _discountForEverydayRate = 0.05;

        private double _discountForProfitablyRate = 0.1;

        private double _pricePerKG = 0.5;

        private double _totalSum = 0;

        private MyCustomCollection<Client> _clients = new MyCustomCollection<Client>();
    }
}
