#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			if ((i + j == 4) || (i == j))
				printf("*");
			else
				printf(" ");
		}
		printf("\n");
	}

	// type here

	system("pause");
	return 0;
}