/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�
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

    printf("�빮�� : %d\n", a);
    printf("�ҹ��� : %d\n", b);
    printf("���� : %d\n", c);
    printf("Ư������ : %d\n", d);
}
// �����Լ�
int main(void) 
{
    char alpha[1000];
    scanf("%s", &alpha);

    printf("\n");
    function(alpha);

	system("pause");
	return EXIT_SUCCESS;
}

