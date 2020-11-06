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
    int a = 10, b = 12;

    printf("a & b = %d\n", a & b);
    printf("a ^ b = %d\n", a ^ b);
    printf("a | b = %d\n", a | b);
    printf("~a : %d\n", ~a);
    printf("a << 1 = %d\n", a << 1);
    printf("a >> 2 = %d\n", a >> 2);

	system("pause");
	return EXIT_SUCCESS;    // return 0; (EXIT_SUCESS = 0)
}