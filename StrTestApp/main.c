/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�, ���ڿ� �н�
  --------------------------------------------------------------------------------
  first created - 2020.02.05
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>

// �����Լ�
int main(void) 
{
    char *dessert = "apple";

    printf("������ �Ľ��� %s�Դϴ�.\n", dessert);
    dessert = "banana";
    printf("������ �Ľ��� %s�Դϴ�.\n", dessert);
	
    system("pause");
	return EXIT_SUCCESS;
}