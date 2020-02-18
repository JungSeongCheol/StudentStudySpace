#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>

int main(void)
{
    int person;
    int rank = 1;
    int temp;
    printf("사람의 수 : ");
    scanf("%d", &person);

    int* num = (int*)malloc(sizeof(int) * person);
    printf("\n");
    printf("점수를 입력 하세요 =>\n");
    for (int i = 0; i < person; i++)
    {
        scanf("%d", &num[i]);
    }
    printf("\n");
    for (int i = 0; i < person; i++)
    {

        for (int j = i + 1; j < person; j++)
        {
            if (num[i] < num[j])
            {
                temp = num[i];
                num[i] = num[j];
                num[j] = temp;
            }
        }


    }

    for (int i = 0; i < person; i++)
    {
        if (num[i] == num[i - 1])
        {
            rank--;
        }


        printf("%d%5d\n", num[i], rank++);

    }
    free(num);


    return 0;
}