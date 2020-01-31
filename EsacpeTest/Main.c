#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif // _MSC_VER

#include <stdio.h>
#include <stdlib.h> // 시스템 헤더 파일

int main()
{
	printf("%d\n", 10);
	printf("%lf\n", 3.4);
	printf("%.1lf\n", 3.45);	//소수점 첫번째자리까지만 출력
	printf("%.10lf\n", 3.4);
	
	printf("%d과 %d의 합은 %d입니다.\n", 10, 20, 10 + 20);

	printf("%.1lf-%.1lf = %.1lf\n", 3.4, 1.2, 3.4 - 1.2);

	// type here

	system("pause");
	return 0;
}