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

void assign10(void);
void assign20(void);

int a;

// 메인함수
int main(void) 
{
  /*  int a = 10, b = 20;

    printf("교환 전 a와 b의 값 : %d, %d\n", a, b);
    {
        int temp;
        int a = 0, b = 0;
        temp = a;
        a = b;
        b = temp;
    }
    printf("교환 후 a와 b의 값 : %d, %d\n", a, b);*/
    printf("a의 값 : %d\n", a);

    assign10();
    assign20();

    printf("a의 값 : %d\n", a);

	system("pause");
	return EXIT_SUCCESS;
}

void assign10(void)
{
    a = 10;
}

void assign20(void)
{
    int a;

    a = 20;
}