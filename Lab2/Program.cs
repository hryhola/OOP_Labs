using System;
using System.Linq;

namespace Hryhola
{
  enum Mark
  {
    Excellent = 5,
    Good = 4,
    Normal = 3,
    Bad = 2,
    VeryBad = 1,
  }

  class Student
  {
    
    public int Age { get; set; }

    public string Name { get; set; }

    public Mark[] Marks { get; set; }

    public int MissedLessonsAmount { get; set; }

    public void PrintMissedLessongAmount()
    {
      Console.WriteLine($"Number of missed lessons by {Name}: {MissedLessonsAmount}");
    }

    public void PrintAverageMark()
    {
      var avg = Marks.Average(a => (int)a);
      Console.WriteLine($"Average mark of {Name}: {avg}");
    }

  }
  static class AreaCalculator
  {
    public static double TrapezoidArea(double ASideLength, double BSideLength, double Height)
    {
      return ((ASideLength + BSideLength) / 2) * Height;
    }
    
    public static double TrapezoidArea(double SidesLength, double Height)
    {
      return TrapezoidArea(SidesLength, SidesLength, Height);
    }

    public static void SetTrapezoidAreaAndPerimeter(double ASideLength, double BSideLength, double CSideLength, double DSideLength, double Height, out double Area, out double Perimeter)
    {
      Area = TrapezoidArea(ASideLength, BSideLength, Height);
      Perimeter = ASideLength + BSideLength + CSideLength + DSideLength; 
    }
  }
  static class Laboratorna2 {
    // Task A
    public static void PrintMyself()
    {
      Console.WriteLine("This is a method that takes no arguments and returns void.");
    }

    // Task B
    public static void PrintArithmeticOpetationsWithNumbers(int a, int b)
    {
      Console.WriteLine($"{a} + {b} = {a + b}");
      Console.WriteLine($"{a} - {b} = {a - b}");
      Console.WriteLine($"{a} * {b} = {a + b}");
      Console.WriteLine($"{a} / {b} = {a + b}");
    }

    // Task C
    public static double GetAverage(double a, double b, double c)
    {
      return (a + b + c) / 3;
    }

    public static void MultiplyBy2(ref double number)
    {
      number *=  2;
    }

    public static double GetAverageIfPositive(params double[] numbers)
    {
      var positive = numbers.Where(n => n > 0);
      return positive.Average();
    }

    public static void Main()
    {
      Console.WriteLine("=========== Task A ===========");
      PrintMyself();
      Console.WriteLine();

      Console.WriteLine("=========== Task B ===========");
      PrintArithmeticOpetationsWithNumbers(123, 321);
      Console.WriteLine();

      Console.WriteLine("=========== Task C ===========");
      Console.WriteLine($"Average form [123.321; 231.312; 421.123] = {GetAverage(123.321, 231.312, 421.123)}\n");

      Console.WriteLine("=========== Trapezoid Area ===========");
      Console.WriteLine($"A side length = 12.2; B side length = 12.1; height = 1.2\nArea = {AreaCalculator.TrapezoidArea(12.2, 12.1, 1.2)}\n");

      Console.WriteLine("=========== Trapezoid Area and Perimeter via out params ===========");
      double Area, Perimeter;
      AreaCalculator.SetTrapezoidAreaAndPerimeter(5, 12, 4, 15, 5, out Area, out Perimeter);
      Console.WriteLine($"A = 5; B = 12; C = 4; B = 15; h = 5\nArea = {Area}\nPerimeter = {Perimeter}\n");

      Console.WriteLine("=========== Multiply by 2 via ref ===========");
      double numer = 123;
      Console.WriteLine($"number = {numer}");
      Console.WriteLine("*** multiplying by 2 via ref ***");
      MultiplyBy2(ref numer);
      Console.WriteLine($"number = {numer}\n");
      
      Console.WriteLine("=========== Getting averange if positive ===========");
      Console.WriteLine($"Average from [1, 2, 3, -1] = {GetAverageIfPositive(1, 2, 3, -1)}\n");
      
      Console.WriteLine("=========== Overloaded Trapezoid Area Method ===========");
      Console.WriteLine($"Sides length: 12, height = 10.\nArea = {AreaCalculator.TrapezoidArea(12, 10)}\n");

      Console.WriteLine("=========== Student Class ===========");
      var Vlad = new Student() { Name = "Vlad", Age = 19, Marks = new Mark[] { Mark.Normal, Mark.Excellent }, MissedLessonsAmount = 10 };
      var Antony = new Student() { Name = "Antony", Age = 21, Marks = new Mark[] { Mark.Excellent, Mark.VeryBad, Mark.Excellent }, MissedLessonsAmount = 11 };
      Vlad.PrintAverageMark();
      Vlad.PrintMissedLessongAmount();
      Console.WriteLine();
      Antony.PrintAverageMark();
      Antony.PrintMissedLessongAmount();

    }
  }
}
