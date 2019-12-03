using System;
using System.Collections.Generic;

namespace AdventOfCode2019.DayTwo
{
    public class IntcodeInterpreter
    {
        private int _programCounter;
        public IList<int> State { get; }

        public IntcodeInterpreter(IList<int> initialState)
        {
            State = initialState;
        }

        public void Run()
        {
            _programCounter = 0;
            while (State.Count >= _programCounter)
            {
                var opcode = State[_programCounter];

                if (opcode == 1)
                {
                    try
                    {
                        var leftLocation = State[_programCounter + 1];
                        var rightLocation = State[_programCounter + 2];
                        var storageLocation = State[_programCounter + 3];
                        State[storageLocation] = State[leftLocation] + State[rightLocation];
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        throw new UnexpectedProgramTermination(e);
                    }

                    _programCounter += 4;
                }
                else if (opcode == 2)
                {
                    try
                    {
                        var leftLocation = State[_programCounter + 1];
                        var rightLocation = State[_programCounter + 2];
                        var storageLocation = State[_programCounter + 3];
                        State[storageLocation] = State[leftLocation] * State[rightLocation];
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        throw new UnexpectedProgramTermination(e);
                    }

                    _programCounter += 4;
                }
                else if (opcode == 99)
                {
                    break;
                }
                else
                {
                    throw new UnexpectedOpcodeException(opcode, _programCounter);
                }
            }
        }
    }

    public class UnexpectedProgramTermination : Exception
    {
        public UnexpectedProgramTermination(Exception inner) : base("", inner)
        {
        }
    }

    public class UnexpectedOpcodeException : Exception
    {
        public UnexpectedOpcodeException(int opcode, int programCounter) : base(
            $"Unexpected opcode {opcode} at index {programCounter}")
        {
        }
    }
}