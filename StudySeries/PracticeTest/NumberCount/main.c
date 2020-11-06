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
#include <string.h>
// 메인함수
int main(void) 
{
    char a[20];
    int num[3] = { 0, };

    scanf("%s", &a);

    for (int i = 0; i < strlen(a); i++)
    {
        if ((a[i] >= 'A') && (a[i] <= 'Z'))
        {
            num[0]++;
        }

        else if ((a[i] >= '0') && (a[i] <= '9'))
        {
            num[1]++;
        }

        else if ((a[i] >= 'a') && (a[i] <= 'z'))
        {
            num[2]++;
        }
    }
    printf("%d", num[0]);
    printf("%d", num[1]);
    printf("%d", num[2]);
	system("pause");
	return EXIT_SUCCESS;
}