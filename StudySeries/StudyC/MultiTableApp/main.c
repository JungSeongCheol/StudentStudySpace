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
    for (int i = 2; i < 10; i++)
    {
        for (int j = 1; j < 10; j++)
        {
            printf("%d*%d=%d\t", i, j, i * j);
        }
        printf("\n");
    }
    // type here.
	system("pause");
	return EXIT_SUCCESS;
}