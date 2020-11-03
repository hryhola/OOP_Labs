using System;

namespace Hryhola
{
  class Program
  {
    static void Task1()
    {
      Console.WriteLine("========= Task 1 =========\n");
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

        if (Double.IsNaN(s1) && alpha + R < 0)
        {
          throw new Exception("Calculating error: s1 is not a number\nTrying execute sqrt on negative number!");
        }

        double beta = (alpha + Math.Sqrt(Math.Pow(s1, 2) * 2 * Math.Pow(C, x)) / (R + Dk * Math.Pow(Math.Sin(C), 2)));
        return beta;
      }

      Console.WriteLine("========= Task 2 =========\n");
      bool hasError = false;
      do
      {
        try
        {
          Console.Write("Enter x: ");
          double x = Convert.ToSingle(Console.ReadLine());
          double beta = getBeta(x);
          Console.WriteLine($"beta = {beta}\n");
          hasError = false;
        }
        catch (Exception e)
        {
          hasError = true;
          Console.WriteLine($"\n{e.Message}\n");
        }
      } while (hasError);
    }

    static void Main(string[] args)
    {
      Task1();
      Task2();
    }
  }
}
