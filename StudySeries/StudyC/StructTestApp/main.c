/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�, ����ü
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
//    printf("���� : %d\n", yuni.pf.age);
//    printf("���� : %.1lf\n", yuni.pf.height);
//    printf("�й� : %d\n", yuni.id);
//    printf("���� : %.1lf\n", yuni.grade);
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
// �����Լ�

int main(void)
{
    struct student s1 = { 315, "ȫ�浿", 2.4 },
                   s2 = { 316, "�̼���", 3.7 },
                   s3 = { 317, "�������", 4.4 };

    struct student max;

    max = s1;
    if (s2.grade > max.grade) max = s2;
    if (s3.grade > max.grade) max = s3;

    printf("�й� : %d\n", max.id);
    printf("�̸� : %s\n", max.name);
    printf("���� : %.1lf\n", max.grade);

    system("pause");
    return EXIT_SUCCESS;
}