/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 전처리 학습
  --------------------------------------------------------------------------------
  first created - 2020.02.10
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "student.h"

// 메인함수
//int main(void) 
//{
//    Student s1 = { 315, "홍길동" };
//
//    printf("학번 : %d, 이름 : %s\n", s1.num, s1.name);
//
//	system("pause");
//	return EXIT_SUCCESS;
//}

//int main(void) 
//{
//    double radius, area;
//
//    printf("반지름을 입력하세요 (100 이하) : ");
//    scanf("%lf", &radius);
//    
//
//    //if (radius > 100)
//    //    ERR_PRN; // 이래도 반지름 100초과 일때가 존재함.
//
//    if (radius > LIMIT)
//        ERR_PRN;
//
//    else
//    {
//        area = PI * radius * radius;
//        printf("원의 면적 : %.2lf (%s)\n", area, MSG);
//    }
//    
//	system("pause");
//	return EXIT_SUCCESS;
//}

//int main(void)
//{
//    int a = 10, b = 20;
//    double x = 11.2, y = 20.3;
//    int res;
//
//    printf("a + b = %d\n", SUM(a, b));
//    printf("x + y = %lf\n", SUM(x, y));
//
//    res = 30 / MUL(2, 5);
//    printf("30 / (2 * 5) = %d\n", res);
//
//    system("pause");
//    return EXIT_SUCCESS;
//}

//int main(void)
//{
//    int a1, a2;
//
//    NAME_CAT(a, 1) = 10;
//    NAME_CAT(a, 2) = 20;
//    PRINT_EXP(a1 + a2);
//    PRINT_EXP(a2 - a1);
//    system("pause");
//    return EXIT_SUCCESS;
//}

int main(void)
{
    int max;

#if VER >= 6
    printf("버전 %d입니다.\n", VER);
#endif  

#if BIT == 16
    max = 32767;
#else
    max = 2147483647;
#endif // BIT == 16

    printf("int형 변수의 최댓값 : %d\n", max);

    system("pause");
    return EXIT_SUCCESS;
}