#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	int a = 0, b = 0, d = 0;
	char c;

	printf("��Ģ���� �Է�(����) : ");
	scanf("%d %c %d", &a, &c, &b);
	
	switch (c)
	{
	case '+':
		d = a + b;
		break;
	case '-':
		d = a - b;
		break;
	case '*':
		d = a * b;
		break;
	case '/':
		d = a / b;
		break;
	default : 
		printf("������ �Է��� �ּ���");
		break;
	}
	printf("%d%c%d=%d", a, c, b, d);



	// type here

	system("pause");
	return 0;
}