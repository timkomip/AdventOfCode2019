using System;
using System.IO;
using System.Linq;
using AdventOfCode2019.DayOne;

namespace AdventOfCode2019.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run code for what day:");
            var line = Console.ReadLine();

            if (int.TryParse(line, out var choice))
            {
                switch (choice)
                {
                    case 1:
                        DayOne();
                        break;
                    default:
                        Console.Error.WriteLine("Invalid choice");
                        break;
                }
            }
            else
            {
                Console.Error.WriteLine("Input must be a valid integer");
            }
        }

        static void DayOne()
        {
            var masses = File
                .ReadLines("./Data/massesForMyModules.txt")
                .Select(m => double.TryParse(m, out var mass) ? mass : 0)
                .Where(m => m > 0);

            var result = FuelCounterUpper.CalculateFuelForMasses(masses);

            Console.WriteLine(
                $"The total fuel required for all the modules in my ship is {result}"
            );
        }
    }
}