using System;
using System.Diagnostics;

namespace Integrate
{
    public class IntegralComputing
    {
        public static void Integrate(double lowerBound, double upperBound, string priority)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double step = 0.00000001;
            double x = lowerBound;
            double funcValue = 0;
            while (x <= upperBound)
            {
                funcValue += Math.Sin(x) * step;
                x += step;
            }
            sw.Stop();
            OnEndMethod?.Invoke(Math.Round(funcValue, 3), lowerBound,
                upperBound, sw.ElapsedMilliseconds, priority);
        }

        public delegate void EndMethod(double res, double lowerBound,
            double upperBound, long ms, string priority);

        public static event EndMethod OnEndMethod;
    }
}
