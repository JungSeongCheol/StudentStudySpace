#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	double weight, height, BMI;

	printf("������(kg) �� Ű(cm) �Է� : ");
	scanf("%lf %lf", &weight, &height);

	BMI = weight / ((height/100.0) * (height / 100.0));

	if ((BMI <= 25.0) && (BMI >= 20.0))
	{
		printf("ǥ���Դϴ�.");
	}

	else
	{
		printf("ü�߰����� �ʿ��մϴ�.");
	}

	system("pause");
	return 0;
}