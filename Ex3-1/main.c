/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>

//3.	�л� 3���� �б޿��� ���� ���� ���� ������ ���� ������ �Է� ���� ��,  �� ���� ���հ� ����� ����ϴ� ���α׷��� �ۼ��Ͻÿ�. 
//���� ����, ����, ���� ������ ����� �ϴ� ����ü student_t �� �����Ѵ�. 
//�л��� 3���̹Ƿ� student_t Ÿ���� ���� 3��, Ȥ�� �迭�� �����Ͽ�, �ش� ������ ������ �Է¹޴´�. 
//�� ������ ������ ���ϴ� �Լ��� ���� �ۼ��Ͽ� ���հ� ����� ���� �� �̸� ����Ѵ�.

typedef struct
{
    int kor;
    int eng;
    int mat;
} student_t;
// �����Լ�

int add1(student_t Add[3]);
int add2(student_t Add[3]);
int add3(student_t Add[3]);

int main(void) 
{
    int sum[3] = { 0 };
    student_t list[3] = { 0 };

    for (int i = 0; i < 3; i++)
    {
        printf("�л� %d �� ���� ���� �Է��ϼ��� : ", i+1);
        scanf("%d", &list[i].kor);
        printf("�л� %d �� ���� ���� �Է��ϼ��� : ", i + 1);
        scanf("%d", &list[i].eng);
        printf("�л� %d �� ���� ���� �Է��ϼ��� : ", i + 1);
        scanf("%d", &list[i].mat);
    }

    printf("\n");

    for (int i = 0; i < 3; i++)
    {
        printf("�л� %d�� ���� : %3d %4d %4d \n", i + 1, list[i].kor, list[i].eng, list[i].mat);
    }

    sum[0] = add1(list);
    sum[1] = add2(list);
    sum[2] = add3(list);

    printf("\n");

    printf("���� ������ ���� : %d\n", sum[0]);
    printf("���� ������ ��� : %.1lf\n", sum[0] / 3.0);
    printf("���� ������ ���� : %d\n", sum[1]);
    printf("���� ������ ��� : %.1lf\n", sum[1] / 3.0);
    printf("���� ������ ���� : %d\n", sum[2]);
    printf("���� ������ ��� : %.1lf\n", sum[2] / 3.0);

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