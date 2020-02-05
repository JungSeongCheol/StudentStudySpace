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
    while (1)
    {
        char str1[80];
        char str2[80];

        scanf("%s", str1);
        scanf("%s", str2);

        if ((str1[0] == 'X' || str2[0] == 'X') == 1)
            break;

        printf("사전에 먼저 나오는 이름 : ");

        if (strcmp(str1, str2) > 0)
        {
            printf("%s\n", str2);
        }

        else
            printf("%s\n", str1);

    }
	system("pause");
	return EXIT_SUCCESS;
}