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

//2.	������ �������� ��ȯ�ϴ� �Լ��� �ۼ��Ͻÿ�. 
//�Լ� �Է� : 0 - 100 ������ ����(����)
//�Լ� ��ȯ�� : ����
//A : 90 - 100
//B : 70 - 89
//C : 60 - 69
//D : 50 - 59 (ǥ��� 50~59��� �Ǿ�������, �̷��ԵǸ� 40-49�� ���� �����Ƿ� 40 - 59�� �����ϰ� ����)
//F : 0 - 39

void fun(int score);
// �����Լ�
int main(void) 
{
    int score;
    printf("������ �Է��ϼ��� : ");
    scanf("%d", &score);

    fun(score);

	system("pause");
	return EXIT_SUCCESS;
}

void fun(int score)
{
    char grade;

    printf("�Է� ");
    if (score < 40)
    {
        grade = 'F';
        printf("���� : %c\n", grade);
    }

    else if (score < 60)
    {
        grade = 'D';
        printf("���� : %c\n", grade);
    }

    else if (score < 70)
    {
        grade = 'C';
        printf("���� : %c\n", grade);
    }

    else if (score < 90)
    {
        grade = 'B';
        printf("���� : %c\n", grade);
    }

    else
    {
        grade = 'A';
        printf("���� : %c\n", grade);
    }
}