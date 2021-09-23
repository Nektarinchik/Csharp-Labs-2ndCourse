using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _053506_Ermolaev_Lab7
{
    class Client
    {
        public Client(string name, string surname)
        {
            Rate = Rates.NONE;
            Name = name;
            Surname = surname;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Client cl = obj as Client;
            if (cl == null)
                return false;
            return cl.Name == Name && cl.Surname == Surname;
        }
        public override int GetHashCode()
        {
            int hashcode = Name.GetHashCode();
            hashcode = 31 * hashcode + Surname.GetHashCode();
            hashcode = 31 * hashcode + Sum.GetHashCode();
            return hashcode;
        }
        public Rates Rate { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                if (new Regex(@"^[A-Z]{1}[a-z]+$").IsMatch(value))
                    _name = value;
                else
                    throw new ArgumentException();
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                if (new Regex(@"^[A-Z]{1}[a-z]+$").IsMatch(value))
                    _surname = value;
                else
                    throw new ArgumentException();
            }
        }

        public void AddNewOrder(Order order)
        {
            _orders.Add(order);
        }

        public IEnumerable<Order> GetEverydayOrders()
        {
            var ordersWithEveryday = _orders.GroupBy(or => or.Rate).Where(or => or.Key == "Everyday");
            IEnumerable<Order> orders = ordersWithEveryday.SelectMany(group => group);
            return orders;
        }

        public IEnumerable<Order> GetProfitablyOrders()
        {
            var ordersWithProfitably = _orders.GroupBy(or => or.Rate).Where(or => or.Key == "Profitably");
            IEnumerable<Order> orders = ordersWithProfitably.SelectMany(group => group);
            return orders;
        }

        public void GetInfoAboutOrders()
        {
            var everydayOrders = from t in _orders where t.Rate == "Everyday" select t;
            var profitablyOrders = from t in _orders where t.Rate == "Profitably" select t;
            Console.WriteLine($"{Name} {Surname} ordered transportation with a rate Everyday for the cost of {SumWithEveryday}$." +
                $"\n{Name} {Surname} ordered transportation with a rate Profitably for the cost of {SumWithProfitably}$." +
                $"\nTotal cost of all orders - {Sum}$.");
        }
        public double Sum { get; set; }

        public double SumWithEveryday { get; set; }

        public double SumWithProfitably { get; set; }

        private List<Order> _orders = new List<Order>();

        private string _name;

        private string _surname;
    } 
}
