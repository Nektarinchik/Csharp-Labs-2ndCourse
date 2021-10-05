using _053506_Ermolaev_Lab10.Entities;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace _053506_Ermolaev_Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName =
                @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab10\053506_Ermolaev_Lab10\Files\Employees.json";
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(18, "Name1", false));
            employees.Add(new Employee(21, "Name2", false));
            employees.Add(new Employee(45, "Name3", true));
            employees.Add(new Employee(25, "Name4", true));
            employees.Add(new Employee(27, "Name5", false));
            Type[] typeArgs = { typeof(Employee) };


            try
            {
                Assembly asm = Assembly.LoadFrom("LibForFiles.dll");
                Type t = asm.GetType("LibForFiles.FileService`1", true);
                t = t.MakeGenericType(typeArgs);
                object obj = Activator.CreateInstance(t);
                MethodInfo Save = t.GetMethod("SaveData");
                Save.Invoke(obj, new object[] { employees, fileName });
                MethodInfo Read = t.GetMethod("ReadFile");
                object infoFromFile = Read.Invoke(obj, new object[] { fileName });
                List<Employee> employeesFromFile = (List<Employee>)infoFromFile;
                foreach (var empl in employeesFromFile)
                {
                    Console.WriteLine(empl.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
