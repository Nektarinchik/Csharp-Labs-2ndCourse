using System.Collections.Generic;

namespace _053506_Ermolaev_Lab8.Entities
{
    class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => x.Name.CompareTo(y.Name);
    }
}
