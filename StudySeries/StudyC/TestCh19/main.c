/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�, ���� ���α׷�
  --------------------------------------------------------------------------------
  first created - 2020.02.11
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define Input scanf("%d %c %d", &a, &c, &b);
#define Add(a, b) (a + b)
#define Sub(a, b) (a - b)
#define Div(a, b) (a / b)
#define Mul(a, b) (a * b)

// �����Լ�
int main(void) 
{
    int a, b;
    char c;

    while(1)
    {
        printf("���� �Է�(���� Ctrl+Z) : ");

        Input;

        if (&a == 26)
        {
            break;
        }


        switch ( c )
        {
        case '+':
            Add(a, b);
            printf(" %d + %d = %d\n", a, b, Add(a, b));
            break;
        case '-':
            Sub(a, b);
            printf(" %d - %d = %d\n", a, b, Sub(a, b));
            break;
        case '*':
            Mul(a, b);
            printf(" %d * %d = %d\n", a, b, Mul(a, b));
            break;
        case '/':
            Div(a, b);
            printf(" %d / %d = %d\n", a, b, Div(a, b));
            break;
        default:
            printf("�����ڸ� �Է��� �ּ���");
        }

    }

    system("pause");
	return EXIT_SUCCESS;
}