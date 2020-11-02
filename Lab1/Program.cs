using System;

namespace Hryhola
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("========= Task 2 =========\n");
            Console.WriteLine("Vladyslav");
            Console.WriteLine("Andriiovych");
            Console.WriteLine("Hryhola\n");
        }

        static void Task2()
        {
            static double getBeta(double x)
            {
                double f = 4.215;
                double alpha = 283.35;
                double C = 6.28;
                double Dk = 8.351;
                double b = -12.6;
                double R = x * b + f;
                double s1 = Math.Sqrt(alpha + R);

                if(Double.IsNaN(s1))
                {
                    Console.WriteLine("Calculating error: s1 is not a number");
                    if(alpha + R < 0) Console.WriteLine("Trying execute sqrt on negative number!");
                }

                double beta = (alpha + Math.Sqrt(Math.Pow(s1, 2) * 2 * Math.Pow(C, x)) / (R + Dk * Math.Pow(Math.Sin(C), 2)));
                return beta;
            }

            Console.WriteLine("========= Task 2 =========\n");

            Console.Write("Enter x: ");
            double x = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine($"beta = {getBeta(x)}\n");

        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
    }
}
