#include "Program.h"
#include <string>
#include <vector>

int main(int argc, char * argv[])
{
    std::vector<std::string> args;
    for (int i = 0; i < argc; ++i)
        args.push_back(std::string(argv[i]));

    Program(args).Run();
}
