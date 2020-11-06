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
#include <string.h>

typedef struct card
{
    int num;
    char name[50];
    char phone[50];
    char email[50];
} Card;
// 메인함수

Card input_business_card();
void show_all_cards();
void search_business_card(int number);
Card* edit_business_card();
Card* delete_business_card();

Card list[50] = { NULL };

int main(void)
{
    int a;
    int number;
    FILE* ofp, *ifp;
    char Save[1000];
    int res;
    char str[80];
    char* aaa;
    char *res1;

    ifp = fopen("card_data.txt", "r");

    printf("1번 입력, 2번 수정, 3번 삭제, 4번 전체출력, 5번 검색, 6번 종료 : ");

    scanf("%d", &a);

    while (a != 6)
    {
        switch (a)
        {
        case 1:
            list[list->num] = input_business_card();
            break;
        case 2:
            edit_business_card(list);
            break;
        case 3:
            delete_business_card();
            break;
        case 4:
            show_all_cards(list);
            break;
        case 5:
            printf("찾을 명함번호를 입력하세요 : ");
            scanf("%d", &number);
            search_business_card(number);
            break;
        default:
            break;
        }
        printf("1번 입력, 2번 수정, 3번 삭제, 4번 전체출력, 5번 검색, 6번 종료 : ");
        scanf("%d", &a);
    }

    ofp = fopen("card_data.txt", "w");

    if (ofp == NULL)
    {
        printf("실행 x");
    }


    for (int i = 0; i < list->num; i++) 
    {
        fputs("이름 : ", ofp);
        fputs(list[i].name, ofp);
        fputs("폰넘버 : ", ofp);
        fputs(list[i].phone, ofp);
        fputs("이메일 : ", ofp);
        fputs(list[i].email, ofp);
        fputs("\n", ofp);
    } //저장완료

    fclose(ofp);
    fclose(ifp);

    system("pause");
    return EXIT_SUCCESS;
}

Card input_business_card()
{
    //if (list[i]->name != list[list->num - 1].name)
    //{
        printf("한글 이름을 입력하세요 : ");
        scanf("%s", &(list->name));
        printf("폰번호를 입력하세요 : ");
        scanf("%s", &(list->phone));
        printf("이메일을 입력하세요 : ");
        scanf("%s", &(list->email));
        (list->num)++;
    //}
    //else
        //printf("입력불가");
    return *list;

}

void show_all_cards()
{
    for (int i = 1; i <= list->num; i++)
    {
        if (list[i].num != 0)
        {
            printf("%d번 카드 %10d%10s%10s%10s\n", list[i].num, list[i].num, list[i].name, list[i].phone, list[i].email);
        }
    }
}

void search_business_card(int number)
{
    printf("%d번 카드 %10d%10s%10s%10s\n", list[number].num, list[number].num, list[number].name, list[number].phone, list[number].email);
}

Card* edit_business_card()
{
    int find;
    printf("찾을 번호를 입력하세요 : ");
    scanf("%d", &find);

    printf("한글 이름을 입력하세요 : ");
    scanf("%s", &(list[find].name));
    printf("폰번호를 입력하세요 : ");
    scanf("%s", &(list[find].phone));
    printf("이메일을 입력하세요 : ");
    scanf("%s", &(list[find].email));

    return list;
}

Card* delete_business_card()
{
    Card ggg = { NULL };
    int bb = 0;
    show_all_cards();
    printf("삭제할 번호를 입력하세요");
    scanf("%d", &bb);

    for (int i = bb; i < list[list->num].num; i++)
    {
        list[i].num = list[i+1].num;
        strcpy(list[i].name, list[i + 1].name);
        strcpy(list[i].phone, list[i + 1].phone);
        strcpy(list[i].email, list[i + 1].email);
    }

    list[list->num] = ggg;
    return list;
}