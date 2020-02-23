
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
    printf("1�� : �Է�\n");
    printf("2�� : ����\n");
    printf("3�� : ����\n");
    printf("4�� : ��ü���\n");
    printf("5�� : �˻�\n");
    printf("6�� : ����\n");
}

void input_business_card() {
    printf("�ѱ��̸��� �Է��ϼ��� : ");
    scanf("%s", List[listnum].name);
    printf("����ȣ�� �Է��ϼ��� : ");
    scanf("%s", List[listnum].pnum);
    printf("�̸����� �Է��ϼ��� : ");
    scanf("%s", List[listnum].email);
    List[listnum].num = number++;
    listnum++;

    system("cls");
}

void show_all_cards() {

    for (int i = 0; i < listnum; i++)
    {
        printf("======================\n");
        printf("���Թ�ȣ : %d\n", List[i].num);
        printf("�ѱ��̸� : %s\n", List[i].name);
        printf("���ѹ� : %s\n", List[i].pnum);
        printf("�̸��� : %s\n", List[i].email);
        printf("======================\n");
    }

    system("pause");
    system("cls");
}

void search_business_card(int num) {

    printf("==================================\n");
    printf("���Թ�ȣ : %d\n", List[num - 1].num);
    printf("�ѱ��̸� : %s\n", List[num - 1].name);
    printf("���ѹ� : %s\n", List[num - 1].pnum);
    printf("�̸��� : %s\n", List[num - 1].email);
    printf("==================================\n");
    system("pause");
    system("cls");
}

void edit_business_card() {
    int inputnum;
    printf(" ���Թ�ȣ �Է� : ");
    scanf("%d", &inputnum);

    printf("�ѱ��̸��� �Է��ϼ��� : ");
    scanf("%s", &List[inputnum - 1].name);
    printf("����ȣ�� �Է��ϼ��� : ");
    scanf("%s", &List[inputnum - 1].pnum);
    printf("�̸����� �Է��ϼ��� : ");
    scanf("%s", &List[inputnum - 1].email);

}

// �����Լ�
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
            printf("���� ��ȣ�� �Է��ϼ���");
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