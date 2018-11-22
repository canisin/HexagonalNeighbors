using System;
using HexagonalNeighbors.Data;

namespace HexagonalNeighbors
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var rand = new Random();
            var grid = new HexGrid(3);
            foreach (var tile in grid.Tiles)
                tile.Value = rand.Next(1, 10);
            grid.Draw();
        }
    }
}