#include <stdio.h>
#include <string>
#include <iostream>
using namespace std; // -> namespace�������� ���� ������ �ݵ�� std::cout�� �������� ����ؾ���.

int main() {
	char str[] = "string";
	string str2 = "string";
	char* c1 = str;
	char* c2;

	c2 = const_cast<char *>(c1);
	puts(c2);
	c2[0] = 'S';

	puts(c2);

	std::cout << "Hello World" << std::endl;

	return 0;
}