/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 3차원 배열 학습
  --------------------------------------------------------------------------------
  first created - 2020.02.05.
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// 메인함수
int main(void) 
{
    int score[2][3][4] = 
    {
        { { 72, 80 , 95, 60 }, { 68, 98, 83, 90 }, { 75, 72, 84, 90 } },
        { { 66, 85 , 90, 88 }, { 95, 92, 88, 95 }, { 43, 72, 56, 75 } }
    };

    int i, j, k;

    for (i = 0; i < 2; i++)
    {
        printf("%d반 점수...\n", i + 1);
        for (j = 0; j < 3; j++)
        {
            for (k = 0; k < 4; k++)
            {
                printf("%5d", score[i][j][k]);
            }
            printf("\n");
        }
        printf("\n");
    }
	system("pause");
	return EXIT_SUCCESS;
}