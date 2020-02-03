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

typedef struct _finddata_t FILE_SEARCH;

void GetfileList(char* path);

// 메인함수
int main(void)
{
    char path[100] = "D:\\";
    GetfileList(path);

    system("pause");
    return EXIT_SUCCESS;
}

void GetfileList(char* path)
{
    long h_file;
    char search_Path[100];
}