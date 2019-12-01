using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.DayOne
{
    public static class FuelCounterUpper
    {
        public static int CalculateFuelForMasses(IEnumerable<double> masses)
        {
            return masses.Sum(mass => (int)Math.Floor(mass / 3) - 2);
        }
    }
}