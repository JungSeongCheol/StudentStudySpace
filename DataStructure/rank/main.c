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
    int arr[1000] = { 0, };
    int num;
    int rank = 1;
    int plus = 1;
    int temp;

    scanf("%d", &num);

    for (int i = 0; i < num; i++)
    {
        scanf("%d", &arr[i]);
    }

    for (int i = (num-1); i >=0; i--)
    {
        for (int j = 0; j < i; j++)
        {
            if (arr[j] < arr[j + 1])
            {
                temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }

    for (int i = 0; i < num; i++)
    {
        if (arr[i] == arr[i-1])
        {
            rank = rank - plus;
            printf("%d %d\n", arr[i], rank);
            rank = rank + plus + 1;
            plus++;
        }
        else
        {
            printf("%d %d\n", arr[i], rank++);
        }
    }
	system("pause");
	return EXIT_SUCCESS;
}