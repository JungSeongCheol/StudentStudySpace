#include <stdio.h>
#include <stdlib.h>

// 메인함수
int main(void)
{

    int m[8] = { 69, 10, 30, 2, 16, 8, 31, 22 };
    int temp = 0;
    int min = 999;
    int k;

    for (int i = 0; i < 8; i++)
    {
        if (i == 7)
        {
            printf("%d", m[i]);
        }
        else
        {
            printf("%d\t", m[i]);
        }
    }
    printf("\n");

    for (int i = 0; i < 8; i++)
    {
        for (int j = i + 1; j < 8; j++)
        {
            if (min > m[j])
            {
                min = m[j];
                k = j; //최소값 배열 m[j]를 맞춰줌.
            }
        }

        if (m[i] > min)
        {
            temp = m[i];
            m[i] = m[k]; 
            m[k] = temp;
        }
      min = 999;

      printf("%3d", m[i]);
    }
    return EXIT_SUCCESS;
}