#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

//������ �迭�� �ٽ�!!
//������ 2�� �ٲ𶧸��� 1�� �پ���
//�Ʒ�, ��, �� , �� �ݺ��Ѵ�.

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

		d = d * -1; //���� ǥ��
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