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

typedef struct
{
    int kor;
    int eng;
    int mat;
} student_t;
// 메인함수

int add1(student_t Add[3]);
int add2(student_t Add[3]);
int add3(student_t Add[3]);

int main(void) 
{
    int sum[3] = { 0 };
    student_t list[3] = { 0 };

    for (int i = 0; i < 3; i++)
    {
        printf("학생 %d 의 국어 값을 입력하세요 : ", i+1);
        scanf("%d", &list[i].kor);
        printf("학생 %d 의 영어 값을 입력하세요 : ", i + 1);
        scanf("%d", &list[i].eng);
        printf("학생 %d 의 수학 값을 입력하세요 : ", i + 1);
        scanf("%d", &list[i].mat);
    }

    printf("\n");

    for (int i = 0; i < 3; i++)
    {
        printf("학생 %d의 성적 : %3d %4d %4d \n", i + 1, list[i].kor, list[i].eng, list[i].mat);
    }

    sum[0] = add1(list);
    sum[1] = add2(list);
    sum[2] = add3(list);

    printf("\n");

    printf("국어 과목의 총합 : %d\n", sum[0]);
    printf("국어 과목의 평균 : %.1lf\n", sum[0] / 3.0);
    printf("영어 과목의 총합 : %d\n", sum[1]);
    printf("영어 과목의 평균 : %.1lf\n", sum[1] / 3.0);
    printf("수학 과목의 총합 : %d\n", sum[2]);
    printf("수학 과목의 평균 : %.1lf\n", sum[2] / 3.0);

	system("pause");
	return EXIT_SUCCESS;
}

int add1(student_t Add[3])
{
    int sum;
    sum = Add[0].kor + Add[1].kor + Add[2].kor;
    return sum;
}

int add2(student_t Add[3])
{
    int sum;
    sum = Add[0].eng + Add[1].eng + Add[2].eng;
    return sum;
}

int add3(student_t Add[3])
{
    int sum;
    sum = Add[0].mat + Add[1].mat + Add[2].mat;
    return sum;
}