using System;
using System.Text.RegularExpressions;

namespace _053506_Ermolaev_Lab5
{
    class Client
    {
        public Client(string name, string surname)
        {
            Rate = Rates.EVERYDAY;
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
            return cl.Name == Name && cl.Surname == Surname
                && cl.Rate == Rate;
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
        public double Sum { get; set; }

        private string _name;

        private string _surname;
    } 
}
