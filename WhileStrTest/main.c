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

// �����Լ�
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

        printf("������ ���� ������ �̸� : ");

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