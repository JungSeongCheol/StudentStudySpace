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

//2.	점수를 학점으로 변환하는 함수를 작성하시오. 
//함수 입력 : 0 - 100 사이의 점수(정수)
//함수 반환값 : 학점
//A : 90 - 100
//B : 70 - 89
//C : 60 - 69
//D : 50 - 59 (표기상 50~59라고 되어있지만, 이렇게되면 40-49의 값이 없으므로 40 - 59로 생각하고 만듦)
//F : 0 - 39

void fun(int score);
// 메인함수
int main(void) 
{
    int score;
    printf("점수를 입력하세요 : ");
    scanf("%d", &score);

    fun(score);

	system("pause");
	return EXIT_SUCCESS;
}

void fun(int score)
{
    char grade;

    printf("입력 ");
    if (score < 40)
    {
        grade = 'F';
        printf("학점 : %c\n", grade);
    }

    else if (score < 60)
    {
        grade = 'D';
        printf("학점 : %c\n", grade);
    }

    else if (score < 70)
    {
        grade = 'C';
        printf("학점 : %c\n", grade);
    }

    else if (score < 90)
    {
        grade = 'B';
        printf("학점 : %c\n", grade);
    }

    else
    {
        grade = 'A';
        printf("학점 : %c\n", grade);
    }
}