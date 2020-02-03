/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>
#include <dirent.h>
#include <string.h>
#include <time.h>
#include <io.h>
#include <conio.h>

typedef struct _finddata_t FILE_SEARCH;

int main(void)
{
    FILE_SEARCH t_file;
    DIR* d;
    struct dirent* dir;
    d = opendir("d:\\");
    char* ext;
    int i;
    char* ggg;
    ggg = ".txt";
    FILE* fp;
    char buffer[100];
    char* tp = "d:\\";
    char* local = "b";
    char ch;
    struct dirent* a;

    while (1)
    {
        if (d)
        {
            while ((dir = readdir(d)) != NULL)
            {
                ext = strrchr(dir->d_name, '.');

                if (ext == NULL)
                {
                    continue;
                }

                i = strcmp(ext, ggg);

                if (i == 0)
                {
                    printf("%s\n", dir->d_name);
                    strcat(tp, dir->d_name);
                    FILE* fp = fopen(dir->d_name, "rt");
                    ch = fgetc(fp);
                    if (ch == EOF)
                        break;
                    putchar(ch);
                }
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
