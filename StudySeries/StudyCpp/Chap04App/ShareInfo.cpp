#include <stdio.h>

class Exchange
{
private:
	static double rate;

public:
	static double GetRate() { return rate; }
	static void SetRate(double aRate) { rate = aRate; }
	double DollarToWon(double d) { return d * rate; }
	double WonToDollar(double w) { return w / rate; }
};
double Exchange::rate;

int main()
{
	Exchange::SetRate(1.1);
	Exchange A, B;
	printf("1달러는 %.0f원이다.\n", A.DollarToWon(1200));
	Exchange::SetRate(1.0);
	printf("1달러는 %.0f원이다.\n", B.DollarToWon(1200));
}
