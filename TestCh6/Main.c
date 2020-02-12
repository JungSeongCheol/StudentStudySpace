#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	int num, pre, line;
	printf("2 이상의 정수를 입력하세요 : ");
	scanf("%d" , &num);
	line = 0;

	for (int i = 2; i < num; i++)
	{
		pre = 1;
		for (int j = 2; j < i; j++)
		{
			if ((i % j) == 0)
			{
				pre = 2;
			}
		}

		if (pre != 2)
		{
			printf("%5d", i);
			line++;
			if ((line % 5) == 0)
				printf("\n");
		}
	}

	// type here

	system("pause");
	return 0;
}