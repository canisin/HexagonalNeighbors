using System;
using System.Linq;

namespace HexagonalNeighbors.Data
{
    public class HexTile
    {
        public readonly Coordinate Coordinate;

        public int Value { get; set; }

        public HexTile(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public HexTile(int x, int y)
            : this(new Coordinate(x, y))
        {
        }

        public void Draw(Grid<char> surface)
        {
            DrawHex(surface);
            DrawValue(surface);
        }

        private void DrawHex(Grid<char> surface)
        {
            //  __
            // /  \
            // \__/
            //

            surface[Coordinate.X * 3 + 0, Coordinate.Y * 1 + 1] = '_';
            surface[Coordinate.X * 3 + 1, Coordinate.Y * 1 + 1] = '_';

            surface[Coordinate.X * 3 - 1, Coordinate.Y * 1 + 0] = '/';
            surface[Coordinate.X * 3 + 2, Coordinate.Y * 1 + 0] = '\\';

            surface[Coordinate.X * 3 - 1, Coordinate.Y * 1 - 1] = '\\';
            surface[Coordinate.X * 3 + 0, Coordinate.Y * 1 - 1] = '_';
            surface[Coordinate.X * 3 + 1, Coordinate.Y * 1 - 1] = '_';
            surface[Coordinate.X * 3 + 2, Coordinate.Y * 1 - 1] = '/';
        }

        private void DrawValue(Grid<char> surface)
        {
            //  __
            // /xx\
            // \__/
            //

            var valueStr = $"{Value,2}";
            if (valueStr.Length > 2)
                throw new ArgumentOutOfRangeException();

            surface[Coordinate.X * 3 + 0, Coordinate.Y * 1 + 0] = valueStr.First();
            surface[Coordinate.X * 3 + 1, Coordinate.Y * 1 + 0] = valueStr.Last();
        }
    }
}