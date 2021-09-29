using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace _053506_Ermolaev_Lab9.Domain
{
    [Serializable]
    public class Company
    {
        public Company() { }
        public Company(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void AddNewDepartment(Department dep) => _departments.Add(dep);

        public void RemoveDepartment(Department dep)
        {
            if (!_departments.Remove(dep))
                throw new ArgumentException("there is no such item in the list");
        }
        public int Count => _departments.Count;

        public void Clear() => _departments.Clear();

        public void GetInfo()
        {
            Console.WriteLine($"Company: {Name}\nDepartments:");
            foreach (Department dep in _departments)
            {
                dep.GetInfo();
            }
        }

        public Department this[int index]
        {
            get
            {
                if (index < 0 || index >= _departments.Count)
                    throw new IndexOutOfRangeException();
                return _departments[index]; 
            }
            set 
            {
                if (index < 0 || index >= _departments.Count)
                    throw new IndexOutOfRangeException();
                _departments[index] = value; 
            }
        }

        private List<Department> _departments = new List<Department>();

        public List<Department> Departments
        {
            get { return _departments; }
            set { _departments = value; }
        }
    }
}
