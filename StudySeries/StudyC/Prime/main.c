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

int PrimeCheck(int num);
// 메인함수
int main(void) 
{
    int num;
    for (int i = 2; i < 100; i++)
    {
         num = PrimeCheck(i);
         if (num == 1)
         {
             printf("%d\t", i);
         }
    }
	system("pause");
	return EXIT_SUCCESS;
}

int PrimeCheck(int num)
{
    int check = 1;
    for (int i = 2; i < num; i++)
    {
        if ((num % i ) == 0)
        {
            check = 0;
            break;
        }
    }

    return check;
}