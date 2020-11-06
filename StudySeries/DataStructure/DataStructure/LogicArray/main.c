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
    int i, n = 0, * ptr;
    int sale[2][4] = { {63, 84, 140, 130}, {157 ,209 ,251 ,312} };

    ptr = &sale[0][0];
    for (int i = 0; i < 8; i++)
    {
        printf("\n address = %u sale %d = %d", ptr, i, *ptr);
        ptr++;
    }

	system("pause");
	return EXIT_SUCCESS;
}