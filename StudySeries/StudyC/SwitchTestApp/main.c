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

// �����Լ�
int main(void) 
{
    int rank = 0, res = 0;
    scanf("%d", &rank);

    //if (rank == 1)
    //{
    //    res = 300;
    //}
    //else if (rank == 2)
    //{
    //    res = 200;
    //}
    //else if (rank == 3)
    //{
    //    res = 100;
    //}
    //else
    //{
    //    res = 10;
    //}

    switch (rank)
    {
    case 1:
        res += 300;
        break;
    case 2:
        res += 200;
        break;
    case 3:
        res += 100;
        break;
    default:
        res += 10;
        break;
    }

	printf("rank = %d, res = %d\n", rank, res);
    // type here.
    
	system("pause");
	return EXIT_SUCCESS;
}