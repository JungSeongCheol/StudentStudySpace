/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�, �Լ� ������ �н�
  --------------------------------------------------------------------------------
  first created - 2020.02.06
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>


// �����Լ�
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