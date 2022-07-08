using AdventOfCode.Console.Core;

namespace AdventOfCode.Challenges
{
    public partial class DiveChallenge : Puzzle
    {
        public static ICoordinate FollowInstructionsFrom(ICoordinate coordinate, string[] lines)
        {
            ICoordinate current = coordinate;
            foreach (string line in lines)
            {
                Instruction instruction = Instruction.Parse(line);
                current = current.Apply(instruction);
            }
            return current;
        }

        public override (Answer First, Answer Second) Run(string[] lines)
        {
            ICoordinate coordinate = new Coordinate(0, 0);
            ICoordinate submarineCoordinate = new SubmarineCoordinate(0, 0, 0);
            coordinate = FollowInstructionsFrom(coordinate, lines);
            submarineCoordinate = FollowInstructionsFrom(submarineCoordinate, lines);
            return (
                new() { Description = "simplistic instructions", Value = coordinate.X * coordinate.Y },
                new() { Description = "submarine instructions", Value = submarineCoordinate.X * submarineCoordinate.Y }
            );
        }

    }
}
