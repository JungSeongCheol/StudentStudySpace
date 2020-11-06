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
//int main(void) 
//{
//    int a[8] = { 69, 10, 30, 2, 16, 8, 31, 22};
//    int temp;
//    for (int i = 7; i > 0; i--)
//    {
//        printf("\n%d 단계", 8 - i);
//        printf("\n");
//        for (int j = 0; j < i; j++)
//        {
//            if (a[j] > a[j+1])
//            {
//                temp = a[j];
//                a[j] = a[j+1];
//                a[j+1] = temp;
//            }
//
//            for (int k = 0; k < 8; k++)
//            {
//                printf("%3d", a[k]);
//            }
//            printf("\n");
//        }
//
//        
//
//    }
//
//    for (int i = 0; i < 8; i++)
//    {
//        printf("%d", a[i]);
//    }
//	system("pause");
//	return EXIT_SUCCESS;
//}

int main()
{
    int a[8] = { 69, 10, 30, 2, 16, 8, 31, 22 };
    int temp;

    for (int i = 7; i > 0; i--)
    {
        printf("%d단계\n", 8 - i);
        for (int j = 0; j < i; j++)
        {
            if (a[j]>a[j+1])
            {
                temp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = temp;
            }

            for (int k = 0; k < 8; k++)
            {
                printf("%3d", a[k]);
            }
            printf("\n");
        }


    }
}