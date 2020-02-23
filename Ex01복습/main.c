
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct data {
    int indexnum;
    int num;
    char name[30];
    char pnum[30];
    char email[30];
} data;

data List[50] = { NULL, };
int listnum = 0;
int number = 1;

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
    printf("한국이름을 입력하세요 : ");
    scanf("%s", List[listnum].name);
    printf("폰번호를 입력하세요 : ");
    scanf("%s", List[listnum].pnum);
    printf("이메일을 입력하세요 : ");
    scanf("%s", List[listnum].email);
    List[listnum].num = number++;
    listnum++;

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

    system("pause");
    system("cls");
}

void search_business_card(int num) {

    printf("==================================\n");
    printf("명함번호 : %d\n", List[num - 1].num);
    printf("한국이름 : %s\n", List[num - 1].name);
    printf("폰넘버 : %s\n", List[num - 1].pnum);
    printf("이메일 : %s\n", List[num - 1].email);
    printf("==================================\n");
    system("pause");
    system("cls");
}

void edit_business_card() {
    int inputnum;
    printf(" 명함번호 입력 : ");
    scanf("%d", &inputnum);

    printf("한국이름을 입력하세요 : ");
    scanf("%s", &List[inputnum - 1].name);
    printf("폰번호를 입력하세요 : ");
    scanf("%s", &List[inputnum - 1].pnum);
    printf("이메일을 입력하세요 : ");
    scanf("%s", &List[inputnum - 1].email);

}

// 메인함수
int main(void)
{
    int input;
    int search;

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
            break;
        case 4:
            system("cls");
            show_all_cards();;
            break;
        case 5:
            system("cls");
            printf("명함 번호를 입력하세요");
            scanf("%d", &search);
            search_business_card(search);
            break;
        case 6:
            exit(1);
        default:
            break;
        }
    }



    // type here.
    system("pause");
    return EXIT_SUCCESS;
}