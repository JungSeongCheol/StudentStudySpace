/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 함수 포인터 학습
  --------------------------------------------------------------------------------
  first created - 2020.02.06
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>


// 메인함수
int main(void) 
{
    int a = 10;
    double b = 20.4;
    void* vp;

    vp = &a;
    printf("a : %d\n", *(int*)vp);

    vp = &b;
    printf("b : %.1lf\n", *(double*)vp);

	system("pause");
	return EXIT_SUCCESS;
}
