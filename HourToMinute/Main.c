#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	int hour, min, sec;
	double time = 3.76;

	hour = (int)time;
	time -= hour;
	time *= 60.0;
	min = (int)time;
	time -= (double)min;
	time *= 60.0;
	sec = (int)time;
	printf("3.76�ð��� %d�ð� %d�� %d���Դϴ�.\n", hour, min, sec);

	system("pause");
	return 0;
}