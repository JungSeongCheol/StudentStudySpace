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

//// 메인함수
//int main(void)
//{
//    int a[8] = { 69, 10, 30, 2, 16, 8, 31, 22 };
//    int min;
//    int temp;
//    for (int i = 0; i < 8; i++)
//    {
//        printf("%3d", a[i]);
//    }
//
//    for (int i = 0; i < 7; i++)
//    {
//        min = i;
//        for (int j = i+1; j < 8; j++)
//        {
//            if (a[min] > a[j])
//            {
//                min = j;
//            }
//
//        }
//        temp = a[i];
//        a[i] = a[min];
//        a[min] = temp;
//        printf(" %d 단계", i+1);
//    }
//
//    printf("\n");
//
//    for (int i = 0; i < 8; i++)
//    {
//        printf("%3d", a[i]);
//    }
//}

int main(void)
{
    int a[8] = { 69, 10, 30, 2, 16, 8, 31, 22 };
    int temp;
    int min;

    for (int i = 0; i < 8; i++)
    {
        printf("%3d", a[i]);
    }

    for (int i = 0; i < 7; i++)
    {
        min = i;
        for (int j = i+1; j < 8; j++)
        {
            if (a[min]>a[j])
            {
                min = j;
            }
        }
        temp = a[i];
        a[i] = a[min];
        a[min] = temp;

        printf("\n%d 단계", i+1);
        for (int t = 0; t < 8; t++)
        {
            printf("%3d", a[t]);
        }
    }

    printf("\n");

    for (int i = 0; i < 8; i++)
    {
        printf("%3d", a[i]);
    }
}