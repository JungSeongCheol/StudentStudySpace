#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	char ch;

	printf("���� �Է� : ");

	scanf("%c", &ch);

	printf("%d", ch);

	system("pause");
	return 0;
}