#include <stdio.h>

class Parent { ; };

class Child : public Parent { ; };

int main() {
	Parent P, * pP;
	Child C, * pC;
	int i = 1234;

	pP = static_cast<Parent*>(&C);
	pC = static_cast<Child*>(&P); // ����� ������ �����ϴ�. //(Child *)&P;
	pP = (Parent*)&i;	// static_cast<Parent*>(&i); �� ���� ���� 

	return 0;
}