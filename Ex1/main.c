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
    int sum = 0;

    for (int i = 0; i <= 300; i++)
    {
        if (i % 3 == 0)
        {
            sum += i;
        }
    }
    printf("1���� 300������ ����(����) �߿��� 3�� �����(3,6,9,12,..)���� ���� : \n");
    printf("%d\n", sum);


	system("pause");
	return EXIT_SUCCESS;
}