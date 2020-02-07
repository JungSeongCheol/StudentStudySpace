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
    int aa[5][6] = { NULL };
    int sum = 0;

    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            aa[i][j] = i*5 + j + 1;
            sum = sum + aa[i][j];
        }
    }

    aa[4][5] = sum;

    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 6; j++)
        {
            printf("%3d ", aa[i][j]);
        }
        printf("\n");
    }

    // type here.
	system("pause");
	return EXIT_SUCCESS;
}