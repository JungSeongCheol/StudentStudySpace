#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	printf("Be happy\n");					// "Be happy" ���, �����ٲ�(\n)
	printf("12345678901234567890\n");		// "12345678901234567890" ���, �����ٲ�(\n)
	printf("My\tfriend\n");					// "My" + (\t) �� ��ġ�� �̵� + "friend" ����� �����ٲ�(\n)

	printf("Goot\bd\tchance\n");			// "Goot" ����� + ��ĭ���� t��ġ�� Ŀ���̵�(\b) + ���� ����ġ�� �̵�(\t)
											// + "chance" ����� �����ٲ�(\n)
	printf("Cow\rW\a\n");					// �� ������ �̵�(\r) �̵��ؼ� C�� W�� ����, ���Ҹ�(\a)�� �����ٲ�(\n) 

	// type here

	system("pause");
	return 0;
}