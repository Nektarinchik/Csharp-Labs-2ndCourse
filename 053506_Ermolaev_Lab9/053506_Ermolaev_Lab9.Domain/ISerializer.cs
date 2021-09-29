using System;
using System.Collections.Generic;

namespace _053506_Ermolaev_Lab9.Domain
{
    public interface ISerializer
    {
        IEnumerable<Company> DeSerializeByLINQ(string fileName);
        IEnumerable<Company> DeSerializeXML(string fileName);
        IEnumerable<Company> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Company> companies, string fileName);
        void SerializeXML(IEnumerable<Company> companies, string fileName);
        void SerializeJSON(IEnumerable<Company> companies, string fileName);

    }
}
