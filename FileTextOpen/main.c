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
    FILE *fp;

    fp = fopen("d:\\a.txt", "r");

    if (fp == NULL)
    {
        printf("������ ������ �ʾҽ��ϴ�.\n");
        return 1;
    }

    printf("������ ���Ƚ��ϴ�.\n");
    fclose(fp);

	system("pause");
	return EXIT_SUCCESS;
}