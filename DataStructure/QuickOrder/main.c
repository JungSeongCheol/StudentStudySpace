/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

//#include <stdio.h>
//#include <stdlib.h>
//
//int Partition(int array[], int left, int right);
//int quick(int array[], int left, int right);
//
//// 메인함수
//int main(void)
//{
//    int Array[8] = { 69, 10, 30, 2, 16, 8, 31, 22 };
//
//    for (int i = 0; i < 8; i++)
//    {
//        printf("%d\t", Array[i]);
//    }
//
//    printf("\n");
//    printf("\n");
//
//    quick(Array, 0, 7);
//
//    for (int i = 0; i < 8; i++)
//    {
//        printf("%d\t", Array[i]);
//    }
//    printf("\n");
//    
//    system("pause");
//    return EXIT_SUCCESS;
//}
//
//int Partition(int array[], int left, int right)
//{
//    int pivot;
//    int temp = 0;
//    int L, R;
//
//    L = left; R = right;
//
//    pivot = (L + R) / 2;
//
//    while (L < R)   //Left가 Right 보다 작을때                      
//    {
//        while ((array[L] < array[pivot]) && (L < R))    
//            L++; //L의 값이 pivot보다 클때 사용된다. -->방향
//
//        while ((array[R] >= array[pivot]) && (L < R))
//            R--; //R의 값이 pivot보다 클때 감소시킨다. <--방향
//
//        temp = array[L];
//        array[L] = array[R];
//        array[R] = temp;
//    }
//
//    temp = array[pivot];
//    array[pivot] = array[R];
//    array[R] = temp;
//
//    return R;
//}
//
//int quick(int array[], int left, int right)
//{
//    int num;
//    if (left < right)
//    {
//        num = Partition(array, left, right);
//        quick(array, left, num - 1);
//        quick(array, num + 1, right);
//    }
//}

#include <stdio.h>
#include <stdlib.h>

int Partition(int array[], int left, int right);
int quick(int array[], int left, int right);
int f;
f = 1;

// 메인함수
int main(void)
{
    int Array[8] = { 69, 10, 30, 2, 16, 8, 31, 22 };

    for (int i = 0; i < 8; i++)
    {
        printf("%d\t", Array[i]);
    }

    printf("\n");
    printf("\n");

    quick(Array, 0, 7);


    system("pause");
    return EXIT_SUCCESS;
}

int Partition(int array[], int left, int right)
{
    int pivot;
    int temp = 0;
    int L, R;
    L = left; R = right;
    pivot = (L + R) / 2;

    while (L < R)   //Left가 Right 보다 작을때                      
    {
        while ((array[L] < array[pivot]) && (L < R))    
            L++;

        while ((array[R] >= array[pivot]) && (L < R))
            R--;

        temp = array[L];
        array[L] = array[R];
        array[R] = temp;
    }

    temp = array[pivot];
    array[pivot] = array[R];
    array[R] = temp;

    printf("[%d단계 : pivot = %d]\n", f, array[pivot]);
    f++;
    for (int i = 0; i < 8; i++)
    {
        printf("%d\t", array[i]);
    }
    printf("\n");

    return R;
}

int quick(int array[], int left, int right)
{
    int num;
    if (left < right)
    {
        num = Partition(array, left, right);
        quick(array, left, num - 1);
        quick(array, num + 1, right);
    }
}