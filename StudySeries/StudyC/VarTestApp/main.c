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

void assign10(void);
void assign20(void);

int a;

// �����Լ�
int main(void) 
{
  /*  int a = 10, b = 20;

    printf("��ȯ �� a�� b�� �� : %d, %d\n", a, b);
    {
        int temp;
        int a = 0, b = 0;
        temp = a;
        a = b;
        b = temp;
    }
    printf("��ȯ �� a�� b�� �� : %d, %d\n", a, b);*/
    printf("a�� �� : %d\n", a);

    assign10();
    assign20();

    printf("a�� �� : %d\n", a);

	system("pause");
	return EXIT_SUCCESS;
}

void assign10(void)
{
    a = 10;
}

void assign20(void)
{
    int a;

    a = 20;
}