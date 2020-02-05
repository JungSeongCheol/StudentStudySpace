/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 문자열 학습
  --------------------------------------------------------------------------------
  first created - 2020.02.05
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>

// 메인함수
int main(void) 
{
    char *dessert = "apple";

    printf("오늘의 후식은 %s입니다.\n", dessert);
    dessert = "banana";
    printf("내일의 후식은 %s입니다.\n", dessert);
	
    system("pause");
	return EXIT_SUCCESS;
}