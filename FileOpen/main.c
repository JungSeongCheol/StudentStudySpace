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
#include <io.h>
#include <sys/types.h>
#include <string.h>
#include <dirent.h>
#include <conio.h>
#include <errno.h>

// 메인함수

int txt_file_only(const struct dirent* info)
{
    char* onlyext;

    onlyext = strrchr(info->d_name, '.');

    if (onlyext == NULL)
    {
        return 1;
    }

    if (strcmp(onlyext, ".txt") == 0)
        return 0;
    else
        return 1;
}
int main(void)
{
    FILE* fp;
    int ch;
    struct dirent** namelist;
    int idx;
    int count;

    i

    fp = fopen("d:\\.txt", "rt");


    if (fp == NULL)
    {
        printf("파일이 열리지 않았습니다.\n");
        return 1;
    }

    printf("\n");
    fclose(fp);

    system("pause");
    return EXIT_SUCCESS;
}



//strrchr(paht, '/') 사용