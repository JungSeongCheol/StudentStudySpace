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
    int sum = 0;

    scanf("%d", &a);

    if (a < 100000000)
    {
        while (a>0)
        {
            sum = sum + a % 10;
            a = a / 10;
        }
    }

    printf("%d", sum);

	system("pause");
	return EXIT_SUCCESS;
}
