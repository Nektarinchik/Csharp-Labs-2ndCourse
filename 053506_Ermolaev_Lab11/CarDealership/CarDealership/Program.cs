using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace CarDealership
{
    class Program
    {
        public static async Task Main()
        {
            Console.WriteLine($"The method Main started working in the thread" +
                $" {Thread.CurrentThread.ManagedThreadId}");

            Entities.CarDealership carDeal = new Entities.CarDealership("MyDealerShip");
            double engineCapacity = 1.4;
            for(int i = 0; i < 100; ++i)
            {
                carDeal.Add(new Entities.Car($"Car{i + 1}", engineCapacity));
                if (i % 10 == 0)
                    engineCapacity += 0.1;
            }

            Stream.StreamService streamServ = new Stream.StreamService();

            using(MemoryStream ms = new MemoryStream())
            {
                await streamServ.WriteToStream(ms, carDeal);

                await streamServ.CopyFromStream(ms,
                    @"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse\053506_Ermolaev_Lab11\CarDealership"
                        + @"\CarDealership\Files\CopiedDealership.xml");
            }

            int count = (streamServ.GetStatisticsAsync(@"C:\Users\MSI\Desktop\Git\Csharp-Labs-2ndCourse" +
                @"\053506_Ermolaev_Lab11\CarDealership\CarDealership\Files\CopiedDealership.xml",
                Entities.CarDealership.isNeedCar)).Result;

            Console.WriteLine($"Number of cars with an engine capacity of more than 2 liters is {count}");

            Console.WriteLine($"The method Main has finished working in the thread" +
                $" {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
