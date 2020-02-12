#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	int res;

	res = (sizeof(short)) > (sizeof(long));

	printf("%d\n", res);

	// type here

	system("pause");
	return 0;
}