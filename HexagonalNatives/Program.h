#pragma once
#include <string>
#include <vector>
#include <iostream>

class Program
{
public:
    Program(const std::vector<std::string> & arguments)
    {
    }

    void Run()
    {
        try
        {
            RunImpl();
        }
        catch (std::exception & err)
        {
            std::cout << err.what() << std::endl;
        }
    }

private:
    void RunImpl()
    {
        std::cout << "Hello world!" << std::endl;
    }
};
