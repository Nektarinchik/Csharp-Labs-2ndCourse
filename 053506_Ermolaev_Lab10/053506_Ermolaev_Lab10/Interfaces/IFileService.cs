using System.Collections.Generic;

namespace _053506_Ermolaev_Lab10.Interfaces
{
    public interface IFileService<T> where T : class
    {
        IEnumerable<T> ReadFile(string fileName);
        void SaveData(IEnumerable<T> data, string fileName);
    }
}
