#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
//int solution(int num)
//{
//	int sum = 0;
//
//	while (num > 0)
//	{
//		sum = sum + num % 10;
//		num = num / 10;
//	}
//	
//	return sum;
//}
//int main()
//{
//	int sum;
//	int num;
//
//	scanf("%d", &num);
//	sum = solution(num);
//
//	printf("%d", sum);
//	system("pause");
//	return 0;
//}


int solution(char* N)
{
	int sum = 0;

	for (int i = 0; i < strlen(N); i++)
	{
		sum += N[i] - 48;
	}

	return sum;
}

int main(void)
{
	char N[100000];

	scanf("%s", &N);

	printf("%d", solution(N));

}