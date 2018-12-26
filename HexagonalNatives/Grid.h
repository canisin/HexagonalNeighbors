#pragma once

#include <unordered_map>
#include "Coordinate.h"

template <typename T>
class Grid : std::unordered_map<Coordinate, T>
{
public:
    T & operator()(const int x, const int y)
    {
        return operator[](Coordinate(x, y));
    }

    void insert(const int x, const int y, const T & t)
    {
        insert(Coordinate(x, y), t);
    }

    size_t erase(const int x, const int y)
    {
        return erase(Coordinate(x, y));
    }
};
