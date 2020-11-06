#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(void)
{
	int Snail[20][20];
	int max = 0;
	int d = 1;
	int x = -1;
	int y = 0;
	int count = 1;
	int jmax;

	scnaf("%d", &max);
	jmax = max;
	
	while (0 <= max)
	{
		for (int i = 0; i < max; i++)
		{
			x = x + d;
			Snail[y][x] = count;
			count;
		}
		max--;

		for (int i = 0; i < max; i++)
		{
			Snail[y][x] = count;
		}
	}

	for (int i = 0; i < jmax; i++)
	{
		for (int j = 0; j < jmax; j++)
		{
			printf("%d\t", Snail[i][j]);
		}
	}

}