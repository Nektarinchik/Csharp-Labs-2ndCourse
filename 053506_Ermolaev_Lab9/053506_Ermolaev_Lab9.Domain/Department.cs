using System;

namespace _053506_Ermolaev_Lab9.Domain
{
    [Serializable]
    public class Department
    {
        public Department() { }
        public Department(string departmentName, int numberOfStaff, Person headOfDepartment)
        {
            DepartmentName = departmentName;
            NumberOfStaff = numberOfStaff;
            HeadOfDepartment = headOfDepartment;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Department dep = obj as Department;
            if (dep == null)
                return false;
            return dep.DepartmentName == DepartmentName 
                && dep.HeadOfDepartment == HeadOfDepartment
                && dep.NumberOfStaff == NumberOfStaff;
        }
        public void GetInfo()
        {
            Console.WriteLine($"Department: {DepartmentName}\n" +
                $"Number of staff: {NumberOfStaff}\n" +
                $"Head of department: {HeadOfDepartment}");
        }
        public string DepartmentName { get; set; }
        public int NumberOfStaff { get; set; }
        public Person HeadOfDepartment { get; set; }
    }
}
