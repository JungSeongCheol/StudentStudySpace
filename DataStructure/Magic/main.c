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

void Draw(int magic[10][10], int num);

// 메인함수
int main(void) 
{
    int magic[10][10] = { 0 };
    int num = 0;

    scanf("%d", &num);

    int C = 0, R = (num-1) / 2;

    for (int i = 1; i <= (num*num); i++)
    {
        magic[C][R] = i; //1의 위치 지정

        if (i % num == 0)
        {
            C++;
        }

        if (C < 0)
        {
            C = (num-1);
        }

        if (R > num)
        {
            R = 0;
        }

        C--;
        R++;

    }

    Draw(magic, num);

	system("pause");
	return EXIT_SUCCESS;
}

void Draw(int magic[10][10], int num)
{
    for (int i = 0; i < num; i++)
    {
        for (int j = 0; j < num; j++)
        {
            printf("%5d", magic[i][j]);
        }
        printf("\n");
    }
}

//for (int i = 0; i < num; i++)
//{
//    for (int j = 0; j < num; j++)
//    {
//        if ((a % num) == 0) //다른 수에서 막히는경우
//        {
//            C = C + 1; //아래 행에서 시작한다.
//        }
//
//        if (C < 0) // 행이 0인경우
//        {
//            C = (num - 1); // 마지막으로 옮긴다/
//        }
//
//        if (R > (num)) // 열이 num인경우
//        {
//            R = 0; // 위로 옮긴다.
//        }
//
//        magic[C][R] = a; // 이동방향
//
//        a = a + 1;
//        C = C - 1;
//        R = R + 1;
//        printf("%5d", magic[i][j]);
//    }
//    printf("\n");
//}