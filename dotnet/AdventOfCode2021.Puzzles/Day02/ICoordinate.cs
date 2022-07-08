namespace AdventOfCode2021.Puzzles
{
    public interface ICoordinate
    {
        public int X { get; }
        public int Y { get; }
        ICoordinate Apply(Instruction instruction);
    }
}
