#include <stdio.h>
#include <string>
#include <iostream>
using namespace std; // -> namespace형식으로 쓰지 않으면 반드시 std::cout의 형식으로 사용해야함.

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