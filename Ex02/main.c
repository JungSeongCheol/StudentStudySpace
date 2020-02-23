
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct data {
    int num;
    char name[30];
    char pnum[30];
    char email[30];
} data;

data List[50] = { NULL, };
int listnum = 0;

void menu() {
    printf("\n");
    printf("1번 : 입력\n");
    printf("2번 : 수정\n");
    printf("3번 : 삭제\n");
    printf("4번 : 전체출력\n");
    printf("5번 : 검색\n");
    printf("6번 : 종료\n");
}

void input_business_card() {
    int check = 0;

    printf("한국이름을 입력하세요 : ");
    scanf("%s", List[listnum].name);
    printf("폰번호를 입력하세요 : ");
    scanf("%s", List[listnum].pnum);
    printf("이메일을 입력하세요 : ");
    scanf("%s", List[listnum].email);

    
    for (int i = 0; i < listnum; i++)
    {
        if ((strcmp(List[listnum].name, List[i].name) == 0) && (strcmp(List[listnum].pnum, List[i].pnum) == 0))
        {
            printf(" 동일한 사람이 이미 있습니다. ");
            check = 1;
            system("pause");
        }
    }

    if (check == 0)
    {
        listnum++;
        List[listnum-1].num = listnum;
    }

    system("cls");
}

void show_all_cards() {


    for (int i = 0; i < listnum; i++)
    {

            printf("======================\n");
            printf("명함번호 : %d\n", List[i].num);
            printf("한국이름 : %s\n", List[i].name);
            printf("폰넘버 : %s\n", List[i].pnum);
            printf("이메일 : %s\n", List[i].email);
            printf("======================\n");
    }


}

void search_business_card(int num) {

    printf("==================================\n");
    printf("명함번호 : %d\n", List[num - 1].num);
    printf("한국이름 : %s\n", List[num - 1].name);
    printf("폰넘버 : %s\n", List[num - 1].pnum);
    printf("이메일 : %s\n", List[num - 1].email);
    printf("==================================\n");

}

void edit_business_card() {
    int inputnum;
    int check = 0;
    char b[30], c[30], d[30];

    printf(" 명함번호 입력 : ");
    scanf("%d", &inputnum);

    strcpy(b, List[inputnum - 1].name);
    strcpy(c, List[inputnum - 1].pnum);
    strcpy(c, List[inputnum - 1].email);

    printf("한국이름을 입력하세요 : ");
    scanf("%s", &b);
    printf("폰번호를 입력하세요 : ");
    scanf("%s", &c);
    printf("이메일을 입력하세요 : ");
    scanf("%s", &d);

    for (int i = 0; i < listnum; i++)
    {
        if ((strcmp(List[inputnum - 1].name, List[i].name) == 0) && (strcmp(List[inputnum - 1].pnum, List[i].pnum) == 0))
        {
            printf(" 동일한 사람이 이미 있습니다. ");
            check = 1;
            system("pause");
        }
    }

    if (check == 0)
    {
        strcpy(List[inputnum - 1].name, b);
        strcpy(List[inputnum - 1].pnum, c);
        strcpy(List[inputnum - 1].email, d);
    }
}

void delete_business_card() {
    int del;
    show_all_cards();
    printf("삭제할 명함번호를 넣으세요 : ");
    scanf("%d", &del);
    int temp;
    temp = listnum;

    for (int i = del - 1; i < List->num; i++)
    {
        List[i].num = List[i + 1].num - 1;
        *(List[i].name) = *(List[i + 1].name);
        *(List[i].pnum) = *(List[i + 1].pnum);
        *(List[i].email) = *(List[i + 1].email);
    }
    List[listnum].num = NULL;
    *(List[listnum].name) = NULL;
    *(List[listnum].pnum) = NULL;
    *(List[listnum].email) = NULL;

    listnum = temp - 1;
    List[listnum].num = listnum;
}

void NewSave() {

    FILE* fp = fopen("card_data.txt", "wt");
    
    if (fp == NULL) {
        printf("파일오픈실패");
        return -1;
    }

    for (int i = 0; i < listnum; i++)
    {
        fprintf(fp, "명함번호 : %d\n", List[i].num);
        fprintf(fp, "한국이름 : %s\n", List[i].name);
        fprintf(fp, "폰넘버 : %s\n", List[i].pnum);
        fprintf(fp, "이메일 : %s\n", List[i].email);
        fprintf(fp, "==================================\n");
    }

    fclose(fp);
}

void OpenFile() {
    FILE* ofp;

    ofp = fopen("card_data.txt", "rt");

    printf("\n 텍스트 파일에 저장된 명함 정보 \n\n");

    for (int i = 0; i < 50; i++)
    {
        fscanf(ofp, "명함번호 : %d\n", &List[i].num);
        fscanf(ofp, "한국이름 : %s\n", &List[i].name);
        fscanf(ofp, "폰넘버 : %s\n", &List[i].pnum);
        fscanf(ofp, "이메일 : %s\n", &List[i].email);
        fscanf(ofp, "==================================\n");
    }

    fclose(ofp);

    listnum = List->num+1;

    show_all_cards();

    system("pause");
    system("cls");
    
}

// 메인함수
int main(void)
{
    int input;
    int search;

    OpenFile();

    while (1)
    {
        menu();
        scanf("%d", &input);

        switch (input)
        {
        case 1:
            system("cls");
            input_business_card();
            break;
        case 2:
            system("cls");
            edit_business_card();
            break;
        case 3:
            delete_business_card();

            break;
        case 4:
            system("cls");    
            show_all_cards();
            system("pause");
            system("cls");
            break;
        case 5:
            system("cls");
            printf("명함 번호를 입력하세요");
            scanf("%d", &search);
            search_business_card(search);
            break;
        case 6:
            NewSave();
            exit(1);
        default:
            break;
        }
    }

    // type here.
    system("pause");
    return EXIT_SUCCESS;
}