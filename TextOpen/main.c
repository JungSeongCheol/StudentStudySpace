/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>
#include "dirent.h" // ���� �ٿ�ε� �ʿ�(window dirent �˻�)
#include <string.h>
#include <time.h>
#include <io.h>
#include <conio.h>

int main(void)
{
    printf("���͸� �Է��ϸ� �ؽ�Ʈ ������ ���Դϴ�.\n");
    printf("x�� �Է��ϸ� �ܼ��� �����ϴ�.\n");


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
                        printf("������ ������ �ʾҽ��ϴ�.");
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
        printf("���͸� �Է��ϸ� �ؽ�Ʈ ������ ���Դϴ�.\n");
        printf("x�� �Է��ϸ� �ܼ��� �����ϴ�.\n");
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