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
char* function(char* n)
{
    char temp[100000];

    for (int i = 0; i < strlen(n); i++)
    {
        temp[i] = n[i];
    }

    for (int i = 0; i < strlen(n); i++)
    {
        n[i] = temp[strlen(n) - 1 - i];
    }

    return n;
}

int main(void)
{
    char n[100000];
    char *b;
    scanf("%s", &n);
    b = function(n);
    printf("%s", b);
}
