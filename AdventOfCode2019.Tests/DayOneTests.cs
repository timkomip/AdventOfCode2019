using AdventOfCode2019.DayOne;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class DayOneTests
    {
        [Theory]
        [InlineData(new double[] {12}, 2)]
        [InlineData(new double[] {14}, 2)]
        [InlineData(new double[] {1969}, 654)]
        [InlineData(new double[] {100756}, 33583)]
        public void FuelCounterUpper_Calculates_Correct_Fuel(double[] masses, int expectedFuel)
        {
            Assert.Equal(expectedFuel, FuelCounterUpper.CalculateFuelForMasses(masses));
        }
    }
}