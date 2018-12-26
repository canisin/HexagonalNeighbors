using System.Collections.Generic;

namespace HexagonalNeighbors.Data
{
    public class Grid<T> : Dictionary<Coordinate, T>
    {
        public T this[int x, int y]
        {
            get => this[new Coordinate(x, y)];
            set => this[new Coordinate(x, y)] = value;
        }

        public void Add(int x, int y, T t) => Add(new Coordinate(x, y), t);

        public void Remove(int x, int y) => Remove(new Coordinate(x, y));

        public bool TryGetValue(int x, int y, out T t) => TryGetValue(new Coordinate(x, y), out t);

        public bool ContainsKey(int x, int y) => ContainsKey(new Coordinate(x, y));
    }
}