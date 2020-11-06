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
#include <string.h>


// 메인함수
int main(void) 
{
    FILE* fp;
    char name[20];
    int age;

    fp = fopen("a.txt", "r");

    if (fp == NULL)
    {
        return EXIT_FAILURE;
    }
    
    fscanf(fp, "%d", &age);
    
    while (fgetc(fp) != '\n')
    {
        
    }

    fgets(name, sizeof(name), fp);
    printf("나이 : %d, 이름 : %s", age, name);
    fclose(fp);
    printf("\n");
	system("pause");
	return EXIT_SUCCESS;
}