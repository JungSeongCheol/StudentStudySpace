#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

//달팽이 배열의 핵심!!
//방향이 2번 바뀔때마다 1씩 줄어든다
//아래, 왼, 위 , 오 반복한다.

int main()
{
	int snail[20][20] = { 0, };
	int num = 0;
	int c = 0, r = -1; 
	int cnt = 1;
	int max;
	int d = 1;

	scanf("%d", &num);
	printf("\n");

	max = num;

	while (0 <= max)
	{
		for (int i = 0; i < max; i++)
		{
			r = r + d;
			snail[c][r] = cnt;
			cnt++;
		}

		max--;

		for (int i = 0; i < max; i++)
		{
			c = c + d;
			snail[c][r] = cnt;
			cnt++;
		}

		d = d * -1; //방향 표현
	}

	for (int i = 0; i < num; i++)
	{
		for (int j = 0; j < num; j++)
		{
			printf("%d\t", snail[i][j]);

		}
		printf("\n");
	}
	system("pause");
	return 0;
}