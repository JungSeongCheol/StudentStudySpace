#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	double weight, height, BMI;

	printf("몸무게(kg) 와 키(cm) 입력 : ");
	scanf("%lf %lf", &weight, &height);

	BMI = weight / ((height/100.0) * (height / 100.0));

	if ((BMI <= 25.0) && (BMI >= 20.0))
	{
		printf("표준입니다.");
	}

	else
	{
		printf("체중관리가 필요합니다.");
	}

	system("pause");
	return 0;
}