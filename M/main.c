/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>

// 메인함수
int main(void) 
{
    int a,b;

    scanf("%d", &a);

    if ((a % 2 == 1))
    {
        b = (a+1)/2;

        for (int i = 0; i < b; i++)
        {
            for (int j = (b - 1); j > i; j--)
            {
                printf(" ");
            }

            for (int j = 0; j <= (2*i); j++)
            {
                printf("*");
            }

            printf("\n");
        }

        for (int i = 0; i < b - 1; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                printf(" ");
            }

            for (int j = a - 1; j > (2 * i)+1; j--)
            {
                printf("*");
            }

            printf("\n");
        }
    }
	system("pause");
	return EXIT_SUCCESS;
}