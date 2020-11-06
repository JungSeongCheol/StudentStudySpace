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
    int a;
    int b;

    scanf("%d", &a);
    scanf("%d", &b);
    printf(" 가로 : %d\n", a);
    printf(" 세로 : %d\n", b);
    printf("넓이 : %d\n", (a * b)/2);
    
	system("pause");
	return EXIT_SUCCESS;
}