using _053506_Ermolaev_Lab9.Domain;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text.Json;
using System.IO;

namespace Serializer.Domain
{
    public class ClSerializer : ISerializer
    {
        public IEnumerable<Company> DeSerializeByLINQ(string fileName)
        {
            XDocument doc = XDocument.Load(fileName);
            List<Company> companies = new List<Company>();
            foreach (XElement elCom in doc.Root.Elements("company"))
            {
                Company com = new Company((string)elCom.Attribute("name"));
                foreach (XElement elDep in elCom.Element("departments").Elements("department"))
                {
                    string depName = (string)elDep.Attribute("name");
                    int numberOfStaff = (int)elDep.Element("number_of_staff");
                    Person headOfDepartment = new Person((string)elDep.Element("head_of_department").Attribute("name"),
                        (string)elDep.Element("head_of_department").Attribute("surname"));
                    Department dep = new Department(depName, numberOfStaff, headOfDepartment);
                    com.AddNewDepartment(dep);
                }
                companies.Add(com);
            }
            return companies;
        }

        public IEnumerable<Company> DeSerializeJSON(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Company>>(jsonString);
        }

        public IEnumerable<Company> DeSerializeXML(string fileName)
        {
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<Company>));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return (List<Company>)xmlFormatter.Deserialize(fs);
            }
        }

        public void SerializeByLINQ(IEnumerable<Company> companies, string fileName)
        {
            XDocument doc = new XDocument();
            var xCompanies = new XElement("companies");
            foreach (Company com in companies)
            {
                var xCom = new XElement("company",
                    new XAttribute("name", com.Name));
                var xDepartments = new XElement("departments");
                for (int i = 0; i < com.Count; ++i)
                {
                    var xDepartment = new XElement("department",
                        new XAttribute("name", com[i].DepartmentName),
                        new XElement("number_of_staff", com[i].NumberOfStaff),
                        new XElement("head_of_department", 
                            new XAttribute("name", com[i].HeadOfDepartment.Name),
                            new XAttribute("surname", com[i].HeadOfDepartment.Surname)));
                    xDepartments.Add(xDepartment);
                }
                xCom.Add(xDepartments);
                xCompanies.Add(xCom);
            }
            doc.Add(xCompanies);
            doc.Save(fileName);
        }

        public void SerializeJSON(IEnumerable<Company> companies, string fileName)
        {
            var jsonString = JsonSerializer.Serialize(companies);
            File.WriteAllText(fileName, jsonString);
        }

        public void SerializeXML(IEnumerable<Company> companies, string fileName)
        {
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<Company>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) 
            {
                xmlFormatter.Serialize(fs, companies);
            }
        }
    }
}