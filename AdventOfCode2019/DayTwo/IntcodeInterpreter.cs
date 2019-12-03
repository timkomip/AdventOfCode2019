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
            ResetProgramCounter();
            while (ProgramHasMoreInstructions)
            {
                switch (Opcode)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Multiply();
                        break;
                    case 99:
                        Terminate();
                        break;
                    default:
                        throw new UnexpectedOpcodeException(Opcode, _programCounter);
                }

                IncrementProgramCounter();
            }
        }

        private int Opcode => State[_programCounter];
        private int LeftOperandIndex => State[_programCounter + 1];
        private int RightOperandIndex => State[_programCounter + 2];
        private int ResultIndex => State[_programCounter + 3];
        private bool ProgramHasMoreInstructions => (State.Count > _programCounter);
        private void Add() => State[ResultIndex] = State[LeftOperandIndex] + State[RightOperandIndex];
        private void Multiply() => State[ResultIndex] = State[LeftOperandIndex] * State[RightOperandIndex];
        private void Terminate() => _programCounter = State.Count;
        private void ResetProgramCounter() => _programCounter = 0;
        private void IncrementProgramCounter() => _programCounter += 4;
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