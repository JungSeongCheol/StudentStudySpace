#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	int a;
	int b;
	int temp;

	scanf("%d", &a);

	if (a % 2 == 0)
	{
		printf("홀수만 입력해 주세요");
	}

	else
	{
		for (int i = 0; i < (a-1)/2; i++)
		{
			for (int j = (a-1)/2; j > i; j--)
			{
				printf(" ");
			}

			for (int j = 0; j <= i*2; j++)
			{
				printf("*");
			}
			printf("\n");
		}

		for (int i = 0; i < (a+1)/2; i++)
		{
			for (int j = 0; j < i; j++)
			{
				printf(" ");
			}

			for (int j = a; j > i*2; j--)
			{
				printf("*");
			}
			printf("\n");
		}
	}
	// type here

	system("pause");
	return 0;
}