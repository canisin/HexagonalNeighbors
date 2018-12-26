using System;
using System.Collections.Generic;
using System.Linq;

namespace HexagonalNeighbors.Data
{
    public class HexGrid
    {
        public readonly int Size;
        private readonly Grid<HexTile> _tiles = new Grid<HexTile>();

        public HexGrid(int size)
        {
            Size = size;

            Initialize();
        }

        public IEnumerable<HexTile> Tiles => _tiles.Values;

        public bool CheckCoordinates(int x, int y) => _tiles.ContainsKey(x, y);

        public int this[int x, int y]
        {
            get
            {
                if (!CheckCoordinates(x, y))
                    throw new ArgumentOutOfRangeException();

                return _tiles[x, y].Value;
            }

            set
            {
                if (!CheckCoordinates(x, y))
                    throw new ArgumentOutOfRangeException();

                _tiles[x, y].Value = value;
            }
        }

        private void CreateTile(int x, int y) => _tiles[x, y] = new HexTile(x, y);

        private void Initialize()
        {
            CreateTile(0, 0);

            for (var i = 1; i < Size; ++i)
            {
                //for (var j = 0; j < 6; ++j)
                //north-east
                for (var k = 0; k < i; ++k)
                    CreateTile(k, 2 * i - k);
                //east
                for (var k = 0; k < i; ++k)
                    CreateTile(i, i - 2 * k);
                //south-east
                for (var k = 0; k < i; ++k)
                    CreateTile(i - k, -i - k);
                //south-west
                for (var k = 0; k < i; ++k)
                    CreateTile(-k, -2 * i + k);
                //west
                for (var k = 0; k < i; ++k)
                    CreateTile(-i, -i + 2 * k);
                //north-west
                for (var k = 0; k < i; ++k)
                    CreateTile(-i + k, i + k);
            }
        }

        public void Draw()
        {
            var surface = new Grid<char>();
            foreach (var tile in _tiles.Values)
                tile.Draw(surface);

            var minX = surface.Keys.Select(c => c.X).Min();
            var maxX = surface.Keys.Select(c => c.X).Max();
            var minY = surface.Keys.Select(c => c.Y).Min();
            var maxY = surface.Keys.Select(c => c.Y).Max();

            var lines = Enumerable.Repeat(0, maxY - minY + 1)
                .Select(i => Enumerable.Repeat(' ', maxX - minX + 1).ToArray())
                .ToArray();

            foreach (var kvp in surface)
                lines[maxY - kvp.Key.Y][kvp.Key.X - minX] = kvp.Value;

            foreach (var line in lines)
                Console.WriteLine(new string(line));
        }
    }
}