#include <stdio.h>

enum Color
{
	Black, White, Red, Green, Blue, Aqua
};

class Test {
private:
	Color mycol;

public:
	Test() {
		mycol = Color::White;
	}

	void OutColor() {
		printf("%d", mycol);
	}
};

int main() {
	Test t;
	t.OutColor();
}