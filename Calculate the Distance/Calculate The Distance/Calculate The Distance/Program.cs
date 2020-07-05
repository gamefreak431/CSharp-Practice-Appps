using System;

namespace Calculate_The_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = 2;
            double x2 = 2;
            double y1 = -4;
            double y2 = 2;
            double ab = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine(ab);
        }
    }
}
