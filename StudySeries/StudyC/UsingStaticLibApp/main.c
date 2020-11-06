/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 라이브러리 사용
  --------------------------------------------------------------------------------
  first created - 2020.02.11
  writer - Jung Seong Cheol.
*/

#include <stdio.h>
#include <stdlib.h>
#include "calc.h"

// 메인함수
int main(void) 
{
   
    puts("┌──────────────────┐");
    puts("│  정적 라이브러리 │"); // 한글의 문자는 2byte를 사용하기 때문에 글자간격이 다르다.
    puts("└──────────────────┘");

    int data[] = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
    int result = get_total(data, 10);
    puts("┌──────────────────┐");
    printf("│  Result in %d   │\n", result);
    puts("└──────────────────┘");
	system("pause");
	return EXIT_SUCCESS;

}