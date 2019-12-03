using System.Collections.Generic;
using AdventOfCode2019.DayTwo;
using Xunit;

namespace AdventOfCode2019.Tests.DayTwo
{
    public class IntcodeInterpreterTests
    {
        [Fact]
        public void Opcode_99_Halts_Program()
        {
            var initState = new[] {99, 3, 4, 5};
            var sut = new IntcodeInterpreter(initState);

            sut.Run();

            Assert.Equal(initState, sut.State);
        }

        [Theory]
        [InlineData(new[] {1, 5, 6, 0, 99, 2, 3}, new[] {5, 5, 6, 0, 99, 2, 3})]
        [InlineData(new[] {1, 0, 0, 0, 99}, new[] {2, 0, 0, 0, 99})]
        public void Opcode_1_Adds(int[] initState, int[] expectedState)
        {
            var sut = new IntcodeInterpreter(initState);

            sut.Run();

            Assert.Equal(expectedState, sut.State);
        }

        [Theory]
        [InlineData(new[] {2, 3, 0, 3, 99}, new[] {2, 3, 0, 6, 99})]
        public void Opcode_2_Multiplies(int[] initState, int[] expectedState)
        {
            var sut = new IntcodeInterpreter(initState);

            sut.Run();

            Assert.Equal(expectedState, sut.State);
        }

        [Fact]
        public void Program_Self_Modification_Works()
        {
            var sut = new IntcodeInterpreter(new[] {1, 1, 1, 4, 99, 5, 6, 0, 99});

            sut.Run();

            Assert.Equal(new int[] {30, 1, 1, 4, 2, 5, 6, 0, 99}, sut.State);
        }

        [Fact]
        public void Throws_Raises_If_Bad_Opcode_Encountered()
        {
            var sut = new IntcodeInterpreter(new[] {666});

            Assert.Throws<UnexpectedOpcodeException>(() => sut.Run());
        }
    }
}