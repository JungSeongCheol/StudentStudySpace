/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 정적변수 학습
  --------------------------------------------------------------------------------
  first created - 2020.02.05.
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>

void auto_func(void);
void static_func(void);
// 메인함수
int main(void) 
{
    int i;

    printf("일반 지역 변수(auto)를 사용한 함수...\n");
    for (i = 0; i < 3; i++)
    {
        auto_func();
    }

    printf("정적 지역 변수(static)를 사용한 함수...\n");
    for (i = 0; i < 3; i++)
    {
        static_func();
    }

	system("pause");
	return EXIT_SUCCESS;
}

void auto_func(void)
{
    auto int a = 0;

    a++;
    printf("%d\n", a);
}

void static_func(void)
{
    static int a;

    a++;
    printf("%d\n", a);
}