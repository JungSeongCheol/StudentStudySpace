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
    register int i;
    auto int sum = 0;

    for (i = 1; i <= 10000; i++)
    {
        sum += i;
    }

    printf("%d\n", sum);

    // type here.
	system("pause");
	return EXIT_SUCCESS;
}