#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	double seats = 70;
	double audience = 65;
	double rate;

	rate = audience / seats * 100.0;

	printf("¿‘¿Â∑¸ : %.1lf%%\n", rate);
	// type here

	system("pause");
	return 0;
}