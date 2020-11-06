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
#include <string.h>

typedef struct card
{
    int num;
    char name[50];
    char phone[50];
    char email[50];
} Card;
// �����Լ�

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

    printf("1�� �Է�, 2�� ����, 3�� ����, 4�� ��ü���, 5�� �˻�, 6�� ���� : ");

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
            printf("ã�� ���Թ�ȣ�� �Է��ϼ��� : ");
            scanf("%d", &number);
            search_business_card(number);
            break;
        default:
            break;
        }
        printf("1�� �Է�, 2�� ����, 3�� ����, 4�� ��ü���, 5�� �˻�, 6�� ���� : ");
        scanf("%d", &a);
    }

    ofp = fopen("card_data.txt", "w");

    if (ofp == NULL)
    {
        printf("���� x");
    }


    for (int i = 0; i < list->num; i++) 
    {
        fputs("�̸� : ", ofp);
        fputs(list[i].name, ofp);
        fputs("���ѹ� : ", ofp);
        fputs(list[i].phone, ofp);
        fputs("�̸��� : ", ofp);
        fputs(list[i].email, ofp);
        fputs("\n", ofp);
    } //����Ϸ�

    fclose(ofp);
    fclose(ifp);

    system("pause");
    return EXIT_SUCCESS;
}

Card input_business_card()
{
    //if (list[i]->name != list[list->num - 1].name)
    //{
        printf("�ѱ� �̸��� �Է��ϼ��� : ");
        scanf("%s", &(list->name));
        printf("����ȣ�� �Է��ϼ��� : ");
        scanf("%s", &(list->phone));
        printf("�̸����� �Է��ϼ��� : ");
        scanf("%s", &(list->email));
        (list->num)++;
    //}
    //else
        //printf("�ԷºҰ�");
    return *list;

}

void show_all_cards()
{
    for (int i = 1; i <= list->num; i++)
    {
        if (list[i].num != 0)
        {
            printf("%d�� ī�� %10d%10s%10s%10s\n", list[i].num, list[i].num, list[i].name, list[i].phone, list[i].email);
        }
    }
}

void search_business_card(int number)
{
    printf("%d�� ī�� %10d%10s%10s%10s\n", list[number].num, list[number].num, list[number].name, list[number].phone, list[number].email);
}

Card* edit_business_card()
{
    int find;
    printf("ã�� ��ȣ�� �Է��ϼ��� : ");
    scanf("%d", &find);

    printf("�ѱ� �̸��� �Է��ϼ��� : ");
    scanf("%s", &(list[find].name));
    printf("����ȣ�� �Է��ϼ��� : ");
    scanf("%s", &(list[find].phone));
    printf("�̸����� �Է��ϼ��� : ");
    scanf("%s", &(list[find].email));

    return list;
}

Card* delete_business_card()
{
    Card ggg = { NULL };
    int bb = 0;
    show_all_cards();
    printf("������ ��ȣ�� �Է��ϼ���");
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