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
char function(char Char[12]);

int main(void) 
{
    char Char[12];
    char temp[12];
    char Char1[12];

    scanf("%s", &Char);

    Char[12] = temp[12];

    printf("%d", strlen(Char));

    printf("%c", Char[0]);

    printf("[");


    for (int i = 0; i < strlen(Char); i++)
    {
        temp[i] = Char[i];
    }

    for (int i = 0; i < strlen(Char); i++)
    {
        if (i <= (strlen(Char) - i -1))
        {
            Char[i] = Char[(strlen(Char) - 1) - i];
            printf("%c,", Char[i]);
            printf("");
        }
    }

    for (int i = 0; i < (strlen(Char)/2); i++)
    {
        printf("%c,", temp[(strlen(Char) / 2) - i - 1]);
    }

    printf("]");

	system("pause");
	return EXIT_SUCCESS;
}
