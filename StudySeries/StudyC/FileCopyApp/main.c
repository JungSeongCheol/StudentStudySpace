/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 파일 복사 학습
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// 메인함수
//int main(void) 
//{
//    FILE* ifp, *ofp;
//    char str[80];
//    char* res;
//
//    ifp = fopen("aa.txt", "r");
//
//    if (ifp == NULL)
//    {
//        printf("입력파일 오픈 실패");
//        return EXIT_FAILURE;
//    }
//    
//    ofp = fopen("bb.txt", "w");
//
//    if (ofp == NULL)
//    {
//        printf("출력파일 오픈 실패");
//        return EXIT_FAILURE;
//    }
//
//    while (1)
//    {
//        res = fgets(str, sizeof(str), ifp);
//        if (res == NULL)
//        {
//            break;
//        }
//        str[strlen(str) - 1] = '\0';
//        fputs(str, ofp);
//        fputs(" ", ofp);
//    }
//    
//    fclose(ifp);
//    fclose(ofp);
//
//	system("pause");
//	return EXIT_SUCCESS;
//}

int main(void)
{
    FILE* ifp, * ofp;
    char name[20];
    int kor, eng, math;
    int total;
    double avg;
    int res;

    ifp = fopen("aaa.txt", "r");
    if (ifp == NULL)
    {
        printf("입력 파일 오픈 실패");
    }

    ofp = fopen("bbb.txt", "w");
    if (ofp == NULL)
    {
        printf("출력 파일 오픈 실패");
    }
    
    while (1)
    {
        res = fscanf(ifp, "%s%d%d%d", name, &kor, &eng, &math);

        if (res == EOF)
        {
            printf("텍스트파일 쓰기 완료\n");
            break;
        }
        total = kor + eng + math;   //총점
        avg = total / 3.0;          //평균
        fprintf(ofp, "%s%5d%7.1lf\n", name, total, avg);
    }

    fclose(ifp);
    fclose(ofp);

    system("pause");
    return EXIT_SUCCESS;
}