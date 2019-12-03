using System;
using System.IO;
using System.Linq;
using AdventOfCode2019.DayOne;
using AdventOfCode2019.DayTwo;

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
                    case 2:
                        DayTwo();
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
                .Where(m => m > 0)
                .ToList();

            var result = FuelCounterUpper.CalculateFuelForMasses(masses);
            var resultIncludingGasMass = FuelCounterUpper.CalculateFuelForMasses(masses, true);

            Console.WriteLine(
                $"The total fuel required for all the modules for my ship is {result}"
            );
            Console.WriteLine(
                $"The total fuel required for all the modules (including gas mass) for my ship is {resultIncludingGasMass}"
            );
        }

        static void DayTwo()
        {
            var state = File
                .ReadAllText("./Data/gravityAssistProgram.txt")
                .Split(',')
                .Select(int.Parse)
                .ToList();

            // As per the instructions....
            state[1] = 12;
            state[2] = 2;

            var interpreter = new IntcodeInterpreter(state);

            interpreter.Run();

            Console.WriteLine(
                $"The value at position 0 is {interpreter.State[0]}"
            );
        }
    }
}