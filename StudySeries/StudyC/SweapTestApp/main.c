/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ� / ������
  --------------------------------------------------------------------------------
  first created - 2020.02.04
  writer - Jung Seong Cheol.
*/

#include <stdio.h>
#include <stdlib.h>

void swap(int pa, int pb);

// �����Լ�
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