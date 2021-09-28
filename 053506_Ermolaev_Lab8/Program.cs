using System;
using _053506_Ermolaev_Lab8.Entities;
using _053506_Ermolaev_Lab8.WorkWithFiles;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _053506_Ermolaev_Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(25, "Employee3", true));
            employees.Add(new Employee(41, "Employee4", true));
            employees.Add(new Employee(27, "Employee5", false));
            employees.Add(new Employee(18, "Employee1", false));
            employees.Add(new Employee(18, "Employee2", false));

            FileService fs = new FileService();

            fs.SaveData(employees, @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab8\053506_Ermolaev_Lab8\Files\MyCollection.txt");

            File.Move(@"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab8\053506_Ermolaev_Lab8\Files\MyCollection.txt",
                @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab8\053506_Ermolaev_Lab8\Files\MyCollectionRenamed.txt", true);

            IEnumerable<Employee> employeesFromFile = new List<Employee>();
            
            employeesFromFile = fs.ReadFile(@"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab8\053506_Ermolaev_Lab8\Files\MyCollectionRenamed.txt");

            var sorted = employeesFromFile.OrderBy(empl => empl, new EmployeeComparer());
            
            foreach (var item in sorted)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
