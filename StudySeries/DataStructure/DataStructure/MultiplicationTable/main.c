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
    int num;
    scanf("%d", &num);

    for (int i = num; i < 10; i++)
    {
        printf("\n");
        for (int j = 1; j < 10; j++)
        {
            printf("%d * %d = %d\n", i, j, i * j);
        }
        printf("---------------------------------------------------");
    }

	system("pause");
	return EXIT_SUCCESS;
}