/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>

//3.	학생 3명의 학급에서 각각 국어 영어 수학의 시험 성적을 입력 받은 후,  각 과목 총합과 평균을 출력하는 프로그램을 작성하시오. 
//먼저 국어, 영어, 수학 성적을 멤버로 하는 구조체 student_t 를 정의한다. 
//학생이 3명이므로 student_t 타입의 변수 3개, 혹은 배열을 정의하여, 해당 변수에 성적을 입력받는다. 
//각 과목의 총합을 구하는 함수를 각각 작성하여 총합과 평균을 구한 후 이를 출력한다.
struct student_t
{
    int kor;
    int eng;
    int mat;
};

// 메인함수
int main(void) 
{
    int a[3];
    int b[3];
    int c[3];
    int sum = 0, sum1 = 0, sum2 = 0;

    for (int i = 0; i < 3; i++)
    {
        printf("학생 %d 의 국어성적을 입력하세요 : ", i+1);
        scanf("%d", &a[i]);
    }

    for (int i = 0; i < 3; i++)
    {
        printf("학생 %d 의 영어성적을 입력하세요 : ", i + 1);
        scanf("%d", &b[i]);
    }

    for (int i = 0; i < 3; i++)
    {
        printf("학생 %d 의 수학성적을 입력하세요 : ", i + 1);
        scanf("%d", &c[i]);
    }

    struct student_t list[3] =
    {
        { a[0], b[0], c[0]}, //학생 1
        { a[1], b[1], c[1]}, //학생 2
        { a[2], b[2], c[2]}, //학생 3
    };

    for (int i = 0; i < 3; i++)
    {
        sum += list[i].kor;
        sum1 += list[i].eng;
        sum2 += list[i].mat;
    }

    printf("\n");
    printf("================국어=영어=수학\n");

    for (int i = 0; i < 3; i++)
    {
        printf("학생 %d의 성적 : %3d %4d %4d \n", i+1, list[i].kor, list[i].eng, list[i].mat);
    }
    
    printf("\n");

    printf("국어 과목의 총합 : %d\n", sum);
    printf("국어 과목의 평균 : %d\n", sum /3);
    printf("영어 과목의 총합 : %d\n", sum1);
    printf("영어 과목의 평균 : %d\n", sum1 / 3);
    printf("수학 과목의 총합 : %d\n", sum2);
    printf("수학 과목의 평균 : %d\n", sum2 / 3);

	system("pause");
	return EXIT_SUCCESS;
}