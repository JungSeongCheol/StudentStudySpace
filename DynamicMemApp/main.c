/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 동적 메모리 할당
  --------------------------------------------------------------------------------
  first created - 2020.02.07.
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>

// 메인함수
int main(void) 
{
    int* pi;
    double* pd;

    pi = (int*)malloc(sizeof(int));

    if (pi == NULL)
    {
        printf("# 메모리가 부족합니다.\n");
    }
    pd = (double*)malloc(sizeof(double));

    *pi = 10;
    *pd = 3.4;

    printf("정수형으로 사용 : %d\n", *pi);
    printf("실수형으로 사용 : %.1lf\n", *pd);

    free(pi);
    free(pd);

	system("pause");
	return EXIT_SUCCESS;
}