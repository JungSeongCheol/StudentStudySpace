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
    char alpha[26];
    char alpha1[26];
    char alpha2[26];

    for (int i = 0; i < 26; i++)
    {
        alpha[i] = 65 + i;

        for (int j = 0; j < 26; j++)
        {
            alpha1[j] = 65 + j;

            for (int k = 0; k < 26; k++)
            {
                alpha2[k] = 65 + k;
                printf("%c%c%c\t", alpha[i] ,alpha1[j], alpha2[k]);
            }
        }
    }
	system("pause");
	return EXIT_SUCCESS;
}