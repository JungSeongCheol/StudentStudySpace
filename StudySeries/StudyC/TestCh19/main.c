/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 계산기 프로그램
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

// 메인함수
int main(void) 
{
    int a, b;
    char c;

    while(1)
    {
        printf("수식 입력(종료 Ctrl+Z) : ");

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
            printf("연산자를 입력해 주세요");
        }

    }

    system("pause");
	return EXIT_SUCCESS;
}