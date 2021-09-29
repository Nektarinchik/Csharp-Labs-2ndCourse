using System;
using System.Collections.Generic;
using _053506_Ermolaev_Lab9.Domain;
using Serializer.Domain;

namespace _053506_Ermolaev_Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            ClSerializer serializer = new ClSerializer();
            List<Company> companies = new List<Company>();

            Company company1 = new Company("Company1");
            company1.AddNewDepartment(new Department("HR", 10, new Person("Name1.1", "Surname1.1")));
            company1.AddNewDepartment(new Department("Accounting", 15, new Person("Name1.2", "Surname1.2")));
            company1.AddNewDepartment(new Department("Planning and economic", 5, new Person("Name1.3", "Surname1.3")));
            companies.Add(company1);

            Company company2 = new Company("Company2");
            company2.AddNewDepartment(new Department("HR", 7, new Person("Name2.1", "Surname2.1")));
            company2.AddNewDepartment(new Department("Accounting", 12, new Person("Name2.2", "Surname2.2")));
            company2.AddNewDepartment(new Department("Planning and economic", 3, new Person("Name2.3", "Surname2.3")));
            companies.Add(company2);

            Company company3 = new Company("Company3");
            company3.AddNewDepartment(new Department("HR", 15, new Person("Name3.1", "Surname3.1")));
            company3.AddNewDepartment(new Department("Accounting", 20, new Person("Name3.2", "Surname3.2")));
            company3.AddNewDepartment(new Department("Planning and economic", 10, new Person("Name3.3", "Surname3.3")));
            companies.Add(company3);

            Company company4 = new Company("Company4");
            company4.AddNewDepartment(new Department("HR", 12, new Person("Name4.1", "Surname4.1")));
            company4.AddNewDepartment(new Department("Accounting", 17, new Person("Name4.2", "Surname4.2")));
            company4.AddNewDepartment(new Department("Planning and economic", 7, new Person("Name4.3", "Surname4.3")));
            companies.Add(company4);

            Company company5 = new Company("Company5");
            company5.AddNewDepartment(new Department("HR", 20, new Person("Name5.1", "Surname5.1")));
            company5.AddNewDepartment(new Department("Accounting", 25, new Person("Name5.2", "Surname5.2")));
            company5.AddNewDepartment(new Department("Planning and economic", 15, new Person("Name5.3", "Surname5.3")));
            companies.Add(company5);

            serializer.SerializeByLINQ(companies,
                @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab9\053506_Ermolaev_Lab9\Files\LINQ-to-XML.xml");
            var companiesSerializedByLINQ = serializer.DeSerializeByLINQ(
                @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab9\053506_Ermolaev_Lab9\Files\LINQ-to-XML.xml");
            Console.WriteLine("With LINQ-to-XML");
            foreach (Company com in companiesSerializedByLINQ)
            {
                com.GetInfo();
            }

            serializer.SerializeXML(companies,
                @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab9\053506_Ermolaev_Lab9\Files\XmlSerializer.xml");
            var companiesSerializedByXmlSerializer = serializer.DeSerializeXML(
                @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab9\053506_Ermolaev_Lab9\Files\XmlSerializer.xml");
            Console.WriteLine("\nWith XmlSerializer");
            foreach (Company com in companiesSerializedByXmlSerializer)
            {
                com.GetInfo();
            }

            serializer.SerializeJSON(companies,
                @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab9\053506_Ermolaev_Lab9\Files\JsonSerialization.json");
            var companiesSerializedByJsonSerializer = serializer.DeSerializeJSON(
                @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab9\053506_Ermolaev_Lab9\Files\JsonSerialization.json");
            Console.WriteLine("\nWith JsonSerializer");
            foreach (Company com in companiesSerializedByJsonSerializer)
            {
                com.GetInfo();
            }
        }
    }
}
