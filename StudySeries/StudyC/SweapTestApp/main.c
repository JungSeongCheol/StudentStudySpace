/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수 / 포인터
  --------------------------------------------------------------------------------
  first created - 2020.02.04
  writer - Jung Seong Cheol.
*/

#include <stdio.h>
#include <stdlib.h>

void swap(int pa, int pb);

// 메인함수
int main(void) 
{
    int a = 15, b = 24;

    swap(&a, &b);
    printf("a:%d, b:%d\n", a, b);

	system("pause");
	return EXIT_SUCCESS;
}

void swap(int *pa, int *pb)
{
    int temp;
    temp = *pa;
    *pa = *pb;
    *pb = temp;
}