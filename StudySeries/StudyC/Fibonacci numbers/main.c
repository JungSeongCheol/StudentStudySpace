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

int fibonacci(int sum);

// 메인함수
int main(void) 
{
    int sum = 0;
    
    sum = fibonacci(10);
    printf("%d", sum);

    system("pause");
    return EXIT_SUCCESS;
}

int fibonacci(int sum)
{
    if (sum == 0)
    {
        sum = 0;
        return sum;
    }

    if (sum == 1)
    {
        sum = 1;
        return sum;
    }

    if (sum == 2)
    {
        sum = 1;
        return sum;
    }

    else if (sum > 2)
    {
        return (fibonacci(sum - 2) + fibonacci(sum - 1)) % 1234567;
    }

}

