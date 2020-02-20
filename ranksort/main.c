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
    int num;
    int a[1000] = { 0, };
    int temp;
    int rank = 1;
    int plus = 1;

    scanf("%d", &num);

    for (size_t i = 0; i < num; i++)
    {
        scanf("%d", &a[i]);
    }

    for (int i = 7; i > 0; i--)
    {
        for (int j = 0; j < i; j++)
        {
            if (a[j] < a[j+1])
            {
                temp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = temp;
            }
        }
    }

    for (int i = 0; i < num; i++)
    {
        printf("\n%d", a[i]);

        if (a[i] == a[i-1])
        {
            rank = rank - plus;
            printf(" %d", rank);
            rank = rank + plus + 1;
        }

        else
            printf(" %d", rank++);
    }

    

	system("pause");
	return EXIT_SUCCESS;
}