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

void function(char* alpha)
{
    int a = 0;
    int b = 0;
    int c = 0;
    int d = 0;

    for (int i = 0; i < strlen(alpha); i++)
    {
        if ((32 < alpha[i]) && (alpha[i] < 127))
        {
            if ((65 <= alpha[i]) && (alpha[i] <= 90))
            {
                a++;
            }

            if ((97 <= alpha[i]) && (alpha[i] <= 122))
            {
                b++;
            }

            if ((48 <= alpha[i]) && (alpha[i] <= 57))
            {
                c++;
            }

            else
                d++;
        }
    }

    printf("대문자 : %d\n", a);
    printf("소문자 : %d\n", b);
    printf("숫자 : %d\n", c);
    printf("특수문자 : %d\n", d);
}
// 메인함수
int main(void) 
{
    char alpha[1000];
    scanf("%s", &alpha);

    printf("\n");
    function(alpha);

	system("pause");
	return EXIT_SUCCESS;
}

