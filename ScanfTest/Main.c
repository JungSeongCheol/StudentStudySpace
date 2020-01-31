#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	char grade;
	char name[20];

	// printf("나이 : %d, 키 : %lf", age, height);
	
	printf("학점을 입력하세요 : ");
	scanf("%c", &grade);
	printf("이름을 입력하세요 :");
	scanf("%s", name);
	printf("학점은 %c, 이름은 %s입니다.", grade, name);
	
	system("pause");
	return 0;
}