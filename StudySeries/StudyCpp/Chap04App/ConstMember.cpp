#include <stdio.h>

class MathCalc {
private:
	const double pie;

public:
	MathCalc(double apie) :pie(apie) { ; }
	void DoCalc(double r) {
		printf("반지름 %.2f인 원의 둘레 = %.2f\n", r, r * 2 * pie);
	}
};

int main()
{
	MathCalc m(3.141592);
	m.DoCalc(5.0);
}