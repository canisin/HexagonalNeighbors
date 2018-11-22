namespace HexagonalNeighbors.Data
{
    public struct Coordinate
    {
        public readonly int X, Y;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
    }
}