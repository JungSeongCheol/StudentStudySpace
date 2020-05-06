#include <stdio.h>
#include <limits>
using namespace std;

int main()
{
	const char* str = "korea";
	int* pi;
	double d = 2147483647;
	int i;
	
	double dd = numeric_limits<double>::max();
	printf("%f\n\n", dd);

	int di = numeric_limits<int>::max();
	printf("%d\n", di);

	i = static_cast<int>(d);
	printf("%d\n", i);
	//pi = static_cast<int*>(str);
	pi = (int*)str;
	/*pi = (int*)str;
	printf("%d %x\n", *pi, *pi);*/
}