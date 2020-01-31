#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	char fruit[20] = "strawberry";

	printf("µş±â : %s\n", fruit);
	printf("µş±âÂ´ : %s %s\n", fruit, "jam");
	strcpy(fruit, "banana");
	printf("ÀÌ¹ø °úÀÏ : %s\n", fruit);
	
	system("pause");
	return 0;
}