/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

//ȯ��: Windows 10 Professional, Visual Studio Community 2019
//���� : C��� ���, ������ OS ���� �ܼ� ���԰��� ���α׷��� ����ϴ�.��������(���Թ�ȣ, �ѱ��̸�, ����ȣ, �̸���)�� �Է�, ����, ������ �� �ִ� ��ɰ� �߰��� �˻��� �� �� �ִ� ��ɵ� ����ϴ�.����¿� ���� ����� main �Լ��� �ٸ� �ҽ��� ����ϴ�.
//
//1�� ����(30)
//- exam01�� ������Ʈ ����.�ֿܼ��� ����� ����� ����
//- 1�� �Է�, 2�� ����, 3�� ����, 4�� ��ü���, 5�� �˻�, 6�� ����� �޴� ǥ��
//- ����ü �迭�� ����Ͽ� �����͸� ������.�迭�� ũ��� ����� ����(50)
//- �������� �Է� �Լ��� input_business_card()�� ����, �Է½ô� �ѱ��̸�, ����ȣ, �̸��ϸ� �Է��ϰ�, ���Թ�ȣ�� 1�������� �ڵ����� ����

//2�� ����(30)
//- ��ü ���������� ����ϴ� �Լ��� show_all_cards()�� ����, ���Թ�ȣ / �ѱ��̸� / ����ȣ / �̸��� ������ ���پ� ���
//- �˻� �ֿܼ��� ���Թ�ȣ �Է¹޾�, �˻������ ��� �� Ű�� ������ �ٽ� �޴��� ���, �Լ��� search_business_card(int num)
//- ���� ����� edit_business_card()�� ���Թ�ȣ �Է����� �˻� �� ����ȣ, �̸����� �ٽ� �Է¹޾� ����



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

Card input_business_card(Card* list);
void show_all_cards(Card* list);
void search_business_card(Card* list, int number);
void edit_business_card(Card* list);

int main(void) 
{
    int a;
    int number;

    Card list[50] = { NULL };


    while (1)
    {
        printf("1�� �Է�, 2�� ����, 3�� ����, 4�� ��ü���, 5�� �˻�, 6�� ���� : ");
        scanf("%d", &a);

        switch (a)
        {
        case 1:
            list[list->num] = input_business_card(list);
            break;
        case 2:
            edit_business_card(list);
            break;
        case 3:
            break;
        case 4:
            show_all_cards(list);
            break;
        case 5:
            printf("ã�� ���Թ�ȣ�� �Է��ϼ��� : ");
            scanf("%d", &number);
            search_business_card(list, number);
            break;
        case 6:
            break;
        default:
            break;
        }
    }


	system("pause");
	return EXIT_SUCCESS;
}

Card input_business_card(Card* list)
{
    printf("�ѱ� �̸��� �Է��ϼ��� : ");
    scanf("%s", &(list->name));
    printf("����ȣ�� �Է��ϼ��� : ");
    scanf("%s", &(list->phone));
    printf("�̸����� �Է��ϼ��� : ");
    scanf("%s", &(list->email));
    (list->num)++;

    return* list;
}

void show_all_cards(Card* list)
{
    for (int i = 1; i <= list->num; i++)
    {
        printf("%d�� ī�� %10d%10s%10s%10s\n", list[i].num, list[i].num, list[i].name, list[i].phone, list[i].email);
    }
}

void search_business_card(Card* list, int number)
{
    printf("%d�� ī�� %10d%10s%10s%10s\n", list[number].num, list[number].num, list[number].name, list[number].phone, list[number].email);
}

void edit_business_card(Card* list)
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