/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>

// �����Լ�
int main(void) 
{
    int a;
    int b;

    scanf("%d", &a);
    scanf("%d", &b);
    printf(" ���� : %d\n", a);
    printf(" ���� : %d\n", b);
    printf("���� : %d\n", (a * b)/2);
    
	system("pause");
	return EXIT_SUCCESS;
}