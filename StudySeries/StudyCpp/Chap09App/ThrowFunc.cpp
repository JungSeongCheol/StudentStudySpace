#include <stdio.h>

void divide(int a, int d) {
	if (d == 0) throw "0���δ� ���� �Ұ�";
	printf("������ ��� = %d�Դϴ�.\n", a / d);
}

int main() {
	try {
		divide(10, 0);

		divide(20, 0);
	}
	catch (const char* message) {
		puts(message);
	}
	

	return 0;
}