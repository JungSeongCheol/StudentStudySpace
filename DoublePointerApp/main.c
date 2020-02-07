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
    int a = 10;
    int* pi;
    int** ppi;

    pi = &a;
    ppi = &pi;

    printf("-------------------------------------------\n");
    printf("변수    변숫값    &연산     *연산    **연산\n");
    printf("-------------------------------------------\n");
    printf("  a%10d%10u\n", a, &a);
    printf(" pi%10u%10u%10d\n", pi, &pi, *pi);
    printf("ppi%10u%10u%10u%10u\n", ppi, &ppi, *ppi, **ppi);
    printf("-------------------------------------------\n");

	system("pause");
	return EXIT_SUCCESS;
}