using _053506_Ermolaev_Lab8.Entities;
using _053506_Ermolaev_Lab8.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace _053506_Ermolaev_Lab8.WorkWithFiles
{
    class FileService : IFileService
    {
        public IEnumerable<Employee> ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException($"there is no file on this path: {fileName}");

            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    int age = reader.ReadInt32();
                    bool higherEducation = reader.ReadBoolean();

                    yield return new Employee(age, name, higherEducation);
                }
            }
        }
        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                foreach (Employee empl in data)
                {
                    writer.Write(empl.Name);
                    writer.Write(empl.Age);
                    writer.Write(empl.HigherEducation);
                }
            }
        }
    }
}
