/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�, ���� �޸� �Ҵ�
  --------------------------------------------------------------------------------
  first created - 2020.02.07.
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>

// �����Լ�
int main(void) 
{
    int* pi;
    int size = 5;
    int count = 0;
    int num = 0;

    pi = (int *)calloc(size, sizeof(int));

    while (1)
    {
        printf("����� �Է��ϼ��� ==> ");
        scanf("%d", &num);

        if (num <= 0)
        {
            break;
        }

        if (count == size)
        {
            size += 5;
            pi = realloc(pi, size * sizeof(int));
        }
        pi[count++] = num;
    }

    for (int i = 0; i < count; i++)
    {
        printf("%d ", pi[i]);
    }
    free(pi);



	system("pause");
	return EXIT_SUCCESS;

}