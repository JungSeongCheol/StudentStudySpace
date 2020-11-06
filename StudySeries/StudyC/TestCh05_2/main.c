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
    int i = 0, j = 0;
    char ch;
    printf("정수를 입력하세요\n");
    scanf("%d", &i);

    printf("수식(+, -, *, /)을 입력하세요\n");
    scanf('c', ch);

    printf("정수를 입력하세요\n");
    scanf("%d", &j);

	system("pause");
	return EXIT_SUCCESS;
}