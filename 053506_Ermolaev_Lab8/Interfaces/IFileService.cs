using _053506_Ermolaev_Lab8.Entities;
using System.Collections.Generic;

namespace _053506_Ermolaev_Lab8.Interfaces
{
    interface IFileService
    {
        IEnumerable<Employee> ReadFile(string fileName);

        void SaveData(IEnumerable<Employee> data, string fileName);
    }
}
