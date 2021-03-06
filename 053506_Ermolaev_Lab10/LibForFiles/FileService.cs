using _053506_Ermolaev_Lab10.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace LibForFiles
{
    public class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            string infoFromJson = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<IEnumerable<T>>(infoFromJson);
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
