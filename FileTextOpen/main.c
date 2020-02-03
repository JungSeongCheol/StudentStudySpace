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


// 메인함수
int main(void) 
{
    FILE *fp;

    fp = fopen("d:\\a.txt", "r");

    if (fp == NULL)
    {
        printf("파일이 열리지 않았습니다.\n");
        return 1;
    }

    printf("파일이 열렸습니다.\n");
    fclose(fp);

	system("pause");
	return EXIT_SUCCESS;
}