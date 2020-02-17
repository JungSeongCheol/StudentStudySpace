#include <stdio.h>
#include <stdlib.h>

long long int powJudge(long long int n);

// 메인함수
int main(void)
{
    long long int n;
    long long int b;

    scanf("%lld", &n);

    b = powJudge(n);
    printf("%lld", b);

    system("pause");
    return EXIT_SUCCESS;
}

long long int powJudge(long long int n)
{
    if (1 <= n <= 50000000000000)
    {
        for (long long int i = 0; i < n; i++)
        {
            if (n == (i * i))
            {
                return ((i + 1) * (i + 1));
            }
        }
        return -1;
    }
}
