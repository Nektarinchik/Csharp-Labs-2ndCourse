using System;

namespace _053506_Ermolaev_Lab9.Domain
{
    [Serializable]
    public class Person
    {
        public Person() { }
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Person per = obj as Person;
            if (per == null)
                return false;
            return per.Name == Name
                && per.Surname == Surname;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
