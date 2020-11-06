/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 구조체
  --------------------------------------------------------------------------------
  first created - 2020.02.07
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//struct profile
//{
//    int age;
//    double height;
//};
//
//struct student
//{
//    struct profile pf;
//    int id;
//    double grade;
//};
//
//int main (void)
//{
//    struct student yuni;
//
//    yuni.pf.age = 17;
//    yuni.pf.height = 164.5;
//    yuni.id = 315;
//    yuni.grade = 4.3;
//
//    printf("나이 : %d\n", yuni.pf.age);
//    printf("나이 : %.1lf\n", yuni.pf.height);
//    printf("학번 : %d\n", yuni.id);
//    printf("성적 : %.1lf\n", yuni.grade);
//
//    system("pause");
//    return EXIT_SUCCESS;
//}
struct student
{
    int id;
    char name[20];
    double grade;
};
// 메인함수

int main(void)
{
    struct student s1 = { 315, "홍길동", 2.4 },
                   s2 = { 316, "이순신", 3.7 },
                   s3 = { 317, "세종대왕", 4.4 };

    struct student max;

    max = s1;
    if (s2.grade > max.grade) max = s2;
    if (s3.grade > max.grade) max = s3;

    printf("학번 : %d\n", max.id);
    printf("이름 : %s\n", max.name);
    printf("학점 : %.1lf\n", max.grade);

    system("pause");
    return EXIT_SUCCESS;
}