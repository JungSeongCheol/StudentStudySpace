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

int factorial(int count);

int main(void)
{
    int a;
    printf("factorial ���ڸ� �Է��ϼ��� : ");
    scanf("%d", &a);
    int result = factorial(a);
    printf("result = %d\n", result);

    system("pause");
    return EXIT_SUCCESS;
}

int factorial(int count)
{
    if (count == 1)
        return 1;

    return count * factorial(count - 1);
}