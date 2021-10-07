using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System;
using System.Xml.Serialization;

namespace Stream
{
    public class StreamService
    {
        public async Task WriteToStream(MemoryStream ms, Entities.CarDealership carDeal)
        {
            await Task.Run(() =>
            {
                string fileName = @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab11"
                    + @"\CarDealership\CarDealership\Files\Dealership.xml";
                Console.WriteLine($"Writing to MemoryStream in the thread" +
                    $" {Thread.CurrentThread.ManagedThreadId} has started");
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(Entities.CarDealership));
                if (File.Exists(fileName))
                    File.Delete(fileName);
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    xmlFormatter.Serialize(fs, carDeal);
                    fs.Seek(0, SeekOrigin.Begin); // setting the position to 0 to CopyTo copies all stream
                    fs.CopyTo(ms);
                }
                Console.WriteLine($"Writing to MemoryStream in the thread" +
                    $" {Thread.CurrentThread.ManagedThreadId} is over");
            }); 
        }
        public async Task CopyFromStream(MemoryStream ms, string fileName)
        {
            await Task.Run(() =>
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
                Console.WriteLine($"Reading from MemoryStream in the thread" +
                    $" {Thread.CurrentThread.ManagedThreadId} has started");
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(Entities.CarDealership));
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    ms.WriteTo(fs);
                }
                Console.WriteLine($"Reading from MemoryStream in the thread" +
                    $" {Thread.CurrentThread.ManagedThreadId} is over");
            });
        }
        public async Task<int> GetStatisticsAsync(string fileName,
        Func<Entities.Car, bool> filter)
        {
            int count = 0;
            await Task.Run(() =>
            {
                Console.WriteLine($"The counting in the GetStatisticsAsync in the thread number " +
                    $"{Thread.CurrentThread.ManagedThreadId} has started");
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(Entities.CarDealership));
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    Entities.CarDealership carDeal = (Entities.CarDealership)xmlFormatter.Deserialize(fs);
                    for (int i = 0; i < carDeal.Count(); ++i) 
                    {
                        if (filter(carDeal[i]))
                            ++count;
                    }
                }
                Console.WriteLine($"The counting in the GetStatisticsAsync in the thread number " +
                    $"{Thread.CurrentThread.ManagedThreadId} is over");
            });
            return count;
        }
    }
}
