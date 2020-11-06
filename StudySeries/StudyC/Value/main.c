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
    int a, b;
    int temp;

    scanf("%d", &a);
    scanf("%d", &b);
    printf("%d", a);
    printf("%d", b);
    
    temp = a;
    a = b;
    b = temp;
    printf("%d\n", a);
    printf("%d\n", b);

    
	system("pause");
	return EXIT_SUCCESS;
}