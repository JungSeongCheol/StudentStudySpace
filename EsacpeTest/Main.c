#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main()
{
	printf("Be happy\n");					// "Be happy" 출력, 줄을바꿈(\n)
	printf("12345678901234567890\n");		// "12345678901234567890" 출력, 줄을바꿈(\n)
	printf("My\tfriend\n");					// "My" + (\t) 탭 위치로 이동 + "friend" 출력후 줄을바꿈(\n)

	printf("Goot\bd\tchance\n");			// "Goot" 출력후 + 한칸전인 t위치로 커서이동(\b) + 그후 탭위치로 이동(\t)
											// + "chance" 출력후 줄을바꿈(\n)
	printf("Cow\rW\a\n");					// 맨 앞으로 이동(\r) 이동해서 C를 W로 변경, 벨소리(\a)후 줄을바꿈(\n) 

	// type here

	system("pause");
	return 0;
}