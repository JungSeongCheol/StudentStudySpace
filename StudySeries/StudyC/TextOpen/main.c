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
#include "dirent.h" // 따로 다운로드 필요(window dirent 검색)
#include <string.h>
#include <time.h>
#include <io.h>
#include <conio.h>

int main(void)
{
    printf("엔터를 입력하면 텍스트 파일이 보입니다.\n");
    printf("x를 입력하면 콘솔이 꺼집니다.\n");


    while (1)
    {
        gofirst:
        getchar();
        struct dirent* dir;
        DIR* d;
        d = opendir("d:\\");
        char* ext;
        int i;
        char* ggg;
        ggg = ".txt";
        FILE* fp;
        int ch;

        if (_kbhit());
        {
            if (_getch() == 'x')
                break;
        }

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
                    char tp[100] = "d:\\";
                    strcat(tp, dir->d_name);

                    fp = fopen(tp, "r");

                    if (fp == NULL)
                    {
                        printf("파일이 열리지 않았습니다.");
                        return 1;
                    }

                    while (1)
                    {
                        ch = fgetc(fp);

                        if (ch == EOF)
                        {
                            break;
                        }
                        putchar(ch);

                    }
                    putchar('\n');
                    fclose(fp);

                }
                dir = readdir(d);
            }
        }

        Sleep(1000);
        system("cls");
        printf("엔터를 입력하면 텍스트 파일이 보입니다.\n");
        printf("x를 입력하면 콘솔이 꺼집니다.\n");
        if (_kbhit());
        {
            if (_getch() == 'x')
                break;
        }

        goto gofirst;

    }
    return(0);
}
/*
if (_kbhit());
{
    if (_getch() == 'x')
        break;
}
*/