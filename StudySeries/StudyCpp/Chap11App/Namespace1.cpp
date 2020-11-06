#include <stdio.h>

class MyClass {
public:
	MyClass() { ; }
	void OutTime() { printf("~~"); }
};

class OtherClass {
public:
	void OutTime() { printf("~~"); }
};

namespace A {
	int A;
	double value;
}

namespace B {
	int value;
}

int value;

int main() {
	int value;

	A::value = 3.14159;
	B::value = 10;

	value = 1;
	::value = 1;
	printf("%f\n", A::value);
	printf("%d\n", B::value);

	return 0;
}