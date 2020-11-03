using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Hryhola
{
  class Size
  {
    public double WidthX { get; set; } // in meters
    public double WidthZ { get; set; } // in meters
    public double Height { get; set; } // in meters

    public override string ToString()
    {
      return $"WidthZ: {WidthX}m | WidthZ: {WidthZ}m | Height: {Height}m";
    }

  }
  class Car
  {
    public static void PrintCats(IEnumerable<Car> Cars)
    {
      Console.WriteLine();
      foreach (Car car in Cars) Console.WriteLine($"{car.ToString()}\n");
    }

    public static string GetStatictics(IEnumerable<Car> Cars)
    {
      var mostPopularColor = Cars.GroupBy(c => c.Color).First().First().Color;
      var mostPopularColorCount = Cars.Where(c => c.Color == mostPopularColor).Count();
      var avgMaxSpeed = Cars.Average(c => c.MaxSpeed);
      var avgMass = Cars.Average(c => c.Mass);
      var avgWidthX = Cars.Average(c => c.Size.WidthX);
      var avgWidthZ = Cars.Average(c => c.Size.WidthZ);
      var avgHeight = Cars.Average(c => c.Size.Height);
      return $"Most popular color: {mostPopularColor} [{mostPopularColorCount} times]\n" +
             $"Average max speed: {avgMaxSpeed} km/h\n" +
             $"Average mass: {avgMass} kg\n" +
             $"Average size: WidthZ: {avgWidthZ}m | WidthX: {avgWidthX}m | Height: {avgHeight}";
    }

    public Car()
    {
      Id = "AAAAA";
      Color = KnownColor.Black;
      MaxSpeed = 90;
      Size = new Size() { WidthX = 4, WidthZ = 2, Height = 2 };
    }

    private double _mass;
    private double _maxSpeed;

    public string Id { get; set; }
    public KnownColor Color { get; set; }
    public double MaxSpeed
    { // in kg
      get { return _maxSpeed; }
      set { if (value > 20 && value < 1000) _maxSpeed = value; else throw new Exception("Speed should me 20 < mass < 1000"); }
    }
    public double Mass
    { // in kg
      get { return _mass; } 
      set { if (value > 199 && value < 2001) _mass = value; else throw new Exception("Mass should me 200 < mass < 1500"); } 
    } 
    public Size Size { get; set; }

    public override string ToString()
    {
      return $"Id: {Id}\nMass: {Mass} kg\nSize: {this.Size.ToString()}\nColor: {Color}\nMax speed: {MaxSpeed} km/h";
    }
  }

  class Program
  {
    static Car AskForCar(string id)
    {
      var colorList = new List<KnownColor>((KnownColor[])Enum.GetValues(typeof(KnownColor)));
      KnownColor color;
      string colorStr;
      int index;
      do
      {
        Console.Write("Color: ");
        colorStr = Console.ReadLine();
        index = colorList.FindIndex(c => c.ToString().ToLower() == colorStr.ToLower());
      } while (index == -1);

      color = colorList[index];

      Console.Write("Max speed (20 - 1000): ");
      int speed = Convert.ToInt32(Console.ReadLine());

      Console.Write("Mass (200 - 1500): ");
      int mass = Convert.ToInt32(Console.ReadLine());

      Console.Write("Height: ");
      int height = Convert.ToInt32(Console.ReadLine());

      Console.Write("WidthX: ");
      int widthX = Convert.ToInt32(Console.ReadLine());

      Console.Write("WidthZ: ");
      int widthZ = Convert.ToInt32(Console.ReadLine());

      return new Car() { Id = id, Color = color, Mass = mass, MaxSpeed = speed, Size = new Size() { Height = height, WidthX = widthX, WidthZ = widthZ } };
    }
    static List<Car> AskForCars()
    {
      int amount = 0;
      do
      {
        try
        {
          Console.Write("Enter cars amount (10 max): ");
          amount = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
        }
      } while (amount > 10 || amount < 1);
      var list = new List<Car>(amount);
      for (int i = 0; i < amount; i++) list.Add(new Car());
      return list;
    }
    static void FillCarsWithValues(ref List<Car> cars)
    {
      foreach (Car car in cars)
      {
        var random = new Random();
        car.Id = random.Next(1000).ToString();
        car.Mass = random.Next(200, 1500);
        var colorList = new List<KnownColor>((KnownColor[])Enum.GetValues(typeof(KnownColor)));
        car.Color = colorList[random.Next(30, 35)];
        car.Size = new Size() { Height = random.Next(1, 4), WidthX = random.Next(2, 6), WidthZ = random.Next(2, 6) };
        int maxSpeed = 0;
        do
        {
          try
          {
            Console.Write($"Enter max speed for car #{car.Id}: ");
            maxSpeed = Convert.ToInt32(Console.ReadLine());
          }
          catch (Exception e)
          {
            Console.WriteLine(e.Message);
          } finally
          {
            if (maxSpeed > 1000 || maxSpeed < 20) Console.WriteLine("Min: 20. Max: 1000. Enter again.");
          }
        } while (maxSpeed > 1009 || maxSpeed < 20);

        car.MaxSpeed = maxSpeed;
      }
    }
    static void Main(string[] args)
    {
      var carsList = AskForCars();

      FillCarsWithValues(ref carsList);

      Car.PrintCats(carsList);

      Console.WriteLine(Car.GetStatictics(carsList));


      string id = "";
      int index;
      do
      {
        try
        {
          Console.Write("\nEnter car's id to change values: ");
          id = Console.ReadLine();
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
        }
        index = carsList.FindIndex(c => c.Id == id);
      } while (index == -1);

      var changedCar = AskForCar(id);

      Console.WriteLine("\nChanged car:\n" + changedCar);
    }
  }
}
