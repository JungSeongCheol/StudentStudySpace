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
struct student_t
{
    int kor;
    int eng;
    int mat;
};

// �����Լ�
int main(void) 
{
    int a[3];
    int b[3];
    int c[3];
    int sum = 0, sum1 = 0, sum2 = 0;

    for (int i = 0; i < 3; i++)
    {
        printf("�л� %d �� ������� �Է��ϼ��� : ", i+1);
        scanf("%d", &a[i]);
    }

    for (int i = 0; i < 3; i++)
    {
        printf("�л� %d �� ������� �Է��ϼ��� : ", i + 1);
        scanf("%d", &b[i]);
    }

    for (int i = 0; i < 3; i++)
    {
        printf("�л� %d �� ���м����� �Է��ϼ��� : ", i + 1);
        scanf("%d", &c[i]);
    }

    struct student_t list[3] =
    {
        { a[0], b[0], c[0]}, //�л� 1
        { a[1], b[1], c[1]}, //�л� 2
        { a[2], b[2], c[2]}, //�л� 3
    };

    for (int i = 0; i < 3; i++)
    {
        sum += list[i].kor;
        sum1 += list[i].eng;
        sum2 += list[i].mat;
    }

    printf("\n");
    printf("================����=����=����\n");

    for (int i = 0; i < 3; i++)
    {
        printf("�л� %d�� ���� : %3d %4d %4d \n", i+1, list[i].kor, list[i].eng, list[i].mat);
    }
    
    printf("\n");

    printf("���� ������ ���� : %d\n", sum);
    printf("���� ������ ��� : %d\n", sum /3);
    printf("���� ������ ���� : %d\n", sum1);
    printf("���� ������ ��� : %d\n", sum1 / 3);
    printf("���� ������ ���� : %d\n", sum2);
    printf("���� ������ ��� : %d\n", sum2 / 3);

	system("pause");
	return EXIT_SUCCESS;
}