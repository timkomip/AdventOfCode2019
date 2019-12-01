using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.DayOne
{
    public static class FuelCounterUpper
    {
        public static int CalculateFuelForMasses(IEnumerable<double> masses, bool includeGasMass = false)
        {
            return masses.Sum(mass => CalculateFuelForMasses(mass, includeGasMass));
        }

        public static int CalculateFuelForMasses(double mass, bool includeGasMass = false)
        {
            var result = (int) Math.Floor(mass / 3) - 2;
            if (!includeGasMass) return result;
            return result > 0 ? result + CalculateFuelForMasses(result, true) : 0;
        }
    }
}