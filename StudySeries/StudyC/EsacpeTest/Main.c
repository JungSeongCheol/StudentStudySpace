#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif // _MSC_VER

#include <stdio.h>
#include <stdlib.h> // �ý��� ��� ����

int main()
{
	printf("%d\n", 10);
	printf("%lf\n", 3.4);
	printf("%.1lf\n", 3.45);	//�Ҽ��� ù��°�ڸ������� ���
	printf("%.10lf\n", 3.4);
	printf("%d�� %d�� ���� %d�Դϴ�.\n", 10, 20, 10 + 20);
	printf("%.1lf-%.1lf = %.1lf\n", 3.4, 1.2, 3.4 - 1.2);

	printf("%.1lf\n", 1e6);
	printf("%.7lf\n", 3.14e-5);
	printf("%le\n", 0.0000314);
	printf("%.2le\n", 0.0000314);

	printf("%c\n", 'A');
	printf("%s\n", "a");
	printf("%c�� %s�Դϴ�.\n", '1', "first");
	printf("%d\n", 'A');

	system("pause");
	return 0;
}