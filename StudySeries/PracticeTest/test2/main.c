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

int main()
{
    for (int i = 2; i < 100; i++)
    {
        if (PrimeCheck(i) == 0)
        {
            printf("%d ", i);
        }
    }
}

int PrimeCheck(int a)
{
    int check = 0;

    for (int i = 2; i < a; i++)
    {
        if ((a % i) == 0)
        {
            check = 1;
            return check;
        }
    }

    return check;
}