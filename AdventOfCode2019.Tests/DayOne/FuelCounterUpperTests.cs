using AdventOfCode2019.DayOne;
using Xunit;

namespace AdventOfCode2019.Tests.DayOne
{
    public class FuelCounterUpperTests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void Calculates_Correct_Fuel_For_Single_Mass(double mass, int expectedFuel)
        {
            Assert.Equal(expectedFuel, FuelCounterUpper.CalculateFuelForMasses(mass));
        }

        [Theory]
        [InlineData(new double[] {12, 14}, 4)]
        public void Calculates_Correct_Fuel_For_Many_Masses(double[] masses, int expectedFuel)
        {
            Assert.Equal(expectedFuel, FuelCounterUpper.CalculateFuelForMasses(masses));
        }

        [Theory]
        [InlineData(new double[] {14}, 2)]
        [InlineData(new double[] {1969}, 966)]
        [InlineData(new double[] {100756}, 50346)]
        public void Calculates_Correct_Fuel_Including_Gas_Mass(double[] masses, int expectedFuel)
        {
            Assert.Equal(expectedFuel, FuelCounterUpper.CalculateFuelForMasses(masses, true));
        }
    }
}