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


typedef struct Student
{
	int num;
	char name[20];
	int kor;
	int eng;
	int mat;
	int sum;
	double avg;
	char grd;
} StudentS;
// 메인함수

char grade(int sum);

int main(void)
{
	StudentS List[5] = { NULL };
	StudentS temp;

	for (int i = 0; i < 5; i++)
	{
		printf("학번 :");
		scanf("%d", &((List + i)->num));
		printf("이름 :");
		scanf("%s", &((List + i)->name));
		printf("국어, 영어, 수학 점수 : ");
		scanf("%d%d%d", &((List + i)->kor), &((List + i)->eng), &((List + i)->mat));
		(List + i)->sum = (List + i)->kor + (List + i)->eng + (List + i)->mat;
		(List + i)->avg = (List + i)->sum / 3.0;
		(List + i)->grd = grade((List + i)->avg);
	}

	printf("#정렬 전 데이터...\n");
	for (int i = 0; i < 5; i++)
	{
		printf("%5d%10s%5d%5d%5d%5d%6.1lf%7c\n", (List + i)->num, (List + i)->name, (List + i)->kor, (List + i)->eng, (List + i)->mat, (List + i)->sum, (List + i)->avg, (List + i)->grd);
	}

	printf("# 정렬 후 데이터...\n");

	for (int i = 0; i < 4; i++)
	{
		for (int j = i + 1; j < 5; j++)
		{
			if ((List+i)->avg < (List + j)->avg)
			{
				temp = List[i];
				List[i] = List[j];
				List[j] = temp;
			}
		}
	}

	for (int i = 0; i < 5; i++)
	{
		printf("%5d%10s%5d%5d%5d%5d%6.1lf%7c\n", (List + i)->num, (List + i)->name, (List + i)->kor, (List + i)->eng, (List + i)->mat, (List + i)->sum, (List + i)->avg, (List + i)->grd);

	}


	system("pause");
	return EXIT_SUCCESS;
}

char grade(int sum)
{
	char ch;
	if (sum < 70) ch = 'F';
	else if (sum < 80) ch = 'C';
	else if (sum < 90) ch = 'B';
	else ch = 'A';

	return ch;
}
