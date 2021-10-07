using System;
using System.Threading;
using System.Threading.Tasks;

namespace Integral
{
    class Program
    {
        static void Main(string[] args)
        {
            double lowerBound = -2.0;
            double upperBound = 2.0;
            Integrate.IntegralComputing.OnEndMethod += (res, lowerBound, upperBound, ms, priority) =>
                Console.WriteLine($"Integrating the sin(x) function from {lowerBound} to {upperBound} took {ms} ms " +
                $"with {priority}" +
                $"\nResult : {res}");

            // Parallel invoke of methods

            Parallel.Invoke(

            () =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                Console.WriteLine("Highest start");
                Integrate.IntegralComputing.Integrate(lowerBound, upperBound,
                    Thread.CurrentThread.Priority.ToString());
                Console.WriteLine("Highest stop");
            },

            () =>
            {
                Console.WriteLine("Lowest start");
                Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                Integrate.IntegralComputing.Integrate(lowerBound, upperBound,
                    Thread.CurrentThread.Priority.ToString());
                Console.WriteLine("Lowest stop");
            });


            // Sequential invoke of methods

            //new Thread(() =>
            //{
            //    Integrate.IntegralComputing.Integrate(lowerBound, upperBound,
            //        Thread.CurrentThread.Priority.ToString());
            //})
            //{
            //    Priority = ThreadPriority.Highest
            //}.Start();

            //new Thread(() =>
            //{
            //    Integrate.IntegralComputing.Integrate(lowerBound, upperBound,
            //        Thread.CurrentThread.Priority.ToString());
            //})
            //{
            //    Priority = ThreadPriority.Lowest
            //}.Start();
        }
    }
}
