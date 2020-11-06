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
    int a;
    int n[20][20];

    scanf("%d", &a);

    for (int i = 0; i < a; i++)
    {
        for (int j = 0; j < a; j++)
        {
            n[i][j] = i + j + 1;

            if (i == a-1)
            {
                n[i][j] = 3 * i - j + 1;
            }

            printf("%d\t", n[i][j]);
        }


        printf("\n");

    }
	system("pause");
	return EXIT_SUCCESS;
}

//5
//
//1  2  3    4  5
//
//16 17 18  19 6
//
//15 24 25  20 7
//
//14 23 22  21 8
//
//13 12 11 10  9