#include <dirent.h>
#include <stdio.h>
#include <conio.h>

int main(void)
{
    DIR* d;
    struct dirent* dir;
    d = opendir("d:\\");

    while (1)
    {
        if (d)
        {
            while ((dir = readdir(d)) != NULL)
            {
                printf("%s\n", dir->d_name);
            }
        }

        if (_kbhit());
        {
            if (_getch() == 'x')
                break;
        }
    }
    closedir(d);
    return(0);
}