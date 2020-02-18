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

void Draw(int magic[10][10], int num);

// �����Լ�
int main(void) 
{
    int magic[10][10] = { 0 };
    int num = 0;

    scanf("%d", &num);

    int C = 0, R = (num-1) / 2;

    for (int i = 1; i <= (num*num); i++)
    {
        magic[C][R] = i; //1�� ��ġ ����

        if (i % num == 0)
        {
            C++;
        }

        if (C < 0)
        {
            C = (num-1);
        }

        if (R > num)
        {
            R = 0;
        }

        C--;
        R++;

    }

    Draw(magic, num);

	system("pause");
	return EXIT_SUCCESS;
}

void Draw(int magic[10][10], int num)
{
    for (int i = 0; i < num; i++)
    {
        for (int j = 0; j < num; j++)
        {
            printf("%5d", magic[i][j]);
        }
        printf("\n");
    }
}

//for (int i = 0; i < num; i++)
//{
//    for (int j = 0; j < num; j++)
//    {
//        if ((a % num) == 0) //�ٸ� ������ �����°��
//        {
//            C = C + 1; //�Ʒ� �࿡�� �����Ѵ�.
//        }
//
//        if (C < 0) // ���� 0�ΰ��
//        {
//            C = (num - 1); // ���������� �ű��/
//        }
//
//        if (R > (num)) // ���� num�ΰ��
//        {
//            R = 0; // ���� �ű��.
//        }
//
//        magic[C][R] = a; // �̵�����
//
//        a = a + 1;
//        C = C - 1;
//        R = R + 1;
//        printf("%5d", magic[i][j]);
//    }
//    printf("\n");
//}