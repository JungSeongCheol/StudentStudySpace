/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�, ���� �޸� �Ҵ�
  --------------------------------------------------------------------------------
  first created - 2020.02.07.
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>

// �����Լ�
int main(void) 
{
    int* pi;
    double* pd;

    pi = (int*)malloc(sizeof(int));

    if (pi == NULL)
    {
        printf("# �޸𸮰� �����մϴ�.\n");
    }
    pd = (double*)malloc(sizeof(double));

    *pi = 10;
    *pd = 3.4;

    printf("���������� ��� : %d\n", *pi);
    printf("�Ǽ������� ��� : %.1lf\n", *pd);

    free(pi);
    free(pd);

	system("pause");
	return EXIT_SUCCESS;
}