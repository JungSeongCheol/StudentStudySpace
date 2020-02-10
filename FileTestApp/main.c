/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 파일 오픈 학습
  --------------------------------------------------------------------------------
  first created - 2020.02.10
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>

// 메인함수
//int main(void) 
//{
//    FILE* fp;
//    char str[] = "banana";
//    int i;
//
//    fp = fopen("b.txt", "w");
//    if (fp == NULL)
//    {
//        printf("파일 생성 실패");
//        return EXIT_FAILURE;
//    }
//    //printf("파일이 열렸습니다.\n");
//    i = 0;
//
//    while (str[i] != '\0')
//    {
//        fputc(str[i], fp);
//        i++;
//    }
//
//    fputc('\n', fp);
//    fclose(fp);
//
//	system("pause");
//	return EXIT_SUCCESS;
//}

//int main(void)
//{
//    int ch;
//
//    while (1)
//    {
//        ch = fgetc(stdin);
//        if (ch == EOF)
//        {
//            break;
//        }
//        fputc(ch, stdout);
//    }
//
//    system("pause");
//    return EXIT_SUCCESS;
//}

//int main(void)
//{
//    FILE* fp;
//    int ary[10] = { 13, 10, 13, 13, 10, 26, 13, 10, 13, 10 };
//    int i, res;
//
//    fp = fopen("c.txt", "wt");
//
//    for (i = 0; i < 10; i++)
//    {
//        fputc(ary[i], fp);
//    }
//    fclose(fp);
//
//    fp = fopen("c.txt", "rt");
//
//    while (1)
//    {
//        res = fgetc(fp);
//        if (res == EOF)
//            break;
//        printf("%4d", res);
//    }
//    printf("\n");
//    fclose(fp);
//    
//    system("pause");
//    return EXIT_SUCCESS;
//}

//int main(void)
//{
//    FILE* fp;
//    char str[20];
//
//    fp = fopen("d.txt", "a+");
//
//    if (fp == NULL)
//    {
//        printf("파일오픈 실패");
//        return EXIT_FAILURE;
//    }
//
//    while (1)
//    {
//        printf("과일 이름 : ");
//        scanf("%s", str);
//
//        if (strcmp(str, "end") == 0)
//        {
//            break;
//        }
//
//        else if (strcmp(str, "list") == 0)
//        {
//            rewind(fp);//fseek(fp, 0, SEEK_SET);
//            while (1)
//            {
//                fgets(str, sizeof(str), fp);
//                if (feof(fp))
//                {
//                    break;
//                }
//                printf("%s", str);
//            }
//        }
//
//        else
//        {
//            fprintf(fp, "%s\n", str);
//        }
//    }
//    printf("\n");
//    fclose(fp);
//
//    system("pause");
//    return EXIT_SUCCESS;
//}

int main(void)
{
    FILE* afp, * bfp;
    int num = 213456;
    int res;

    afp = fopen("a.txt", "wt");
    if (afp == NULL)
    {
        return EXIT_FAILURE;
    }

    fprintf(afp, "%d", num);
    
    bfp = fopen("b.txt", "wb");
    if (bfp == NULL)
    {
        return EXIT_FAILURE;
    }
    fwrite(&num, sizeof(num), 1, bfp);

    fclose(afp);
    fclose(bfp);

    bfp = fopen("b.txt", "rb");
    fread(&res, sizeof(res), 1, bfp);
    printf("%d", res);

    fclose(bfp);
    printf("\n");

    system("pause");
    return EXIT_SUCCESS;
}