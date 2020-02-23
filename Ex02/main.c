
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
    printf("1�� : �Է�\n");
    printf("2�� : ����\n");
    printf("3�� : ����\n");
    printf("4�� : ��ü���\n");
    printf("5�� : �˻�\n");
    printf("6�� : ����\n");
}

void input_business_card() {
    int check = 0;

    printf("�ѱ��̸��� �Է��ϼ��� : ");
    scanf("%s", List[listnum].name);
    printf("����ȣ�� �Է��ϼ��� : ");
    scanf("%s", List[listnum].pnum);
    printf("�̸����� �Է��ϼ��� : ");
    scanf("%s", List[listnum].email);

    
    for (int i = 0; i < listnum; i++)
    {
        if ((strcmp(List[listnum].name, List[i].name) == 0) && (strcmp(List[listnum].pnum, List[i].pnum) == 0))
        {
            printf(" ������ ����� �̹� �ֽ��ϴ�. ");
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
            printf("���Թ�ȣ : %d\n", List[i].num);
            printf("�ѱ��̸� : %s\n", List[i].name);
            printf("���ѹ� : %s\n", List[i].pnum);
            printf("�̸��� : %s\n", List[i].email);
            printf("======================\n");
    }


}

void search_business_card(int num) {

    printf("==================================\n");
    printf("���Թ�ȣ : %d\n", List[num - 1].num);
    printf("�ѱ��̸� : %s\n", List[num - 1].name);
    printf("���ѹ� : %s\n", List[num - 1].pnum);
    printf("�̸��� : %s\n", List[num - 1].email);
    printf("==================================\n");

}

void edit_business_card() {
    int inputnum;
    int check = 0;
    char b[30], c[30], d[30];

    printf(" ���Թ�ȣ �Է� : ");
    scanf("%d", &inputnum);

    strcpy(b, List[inputnum - 1].name);
    strcpy(c, List[inputnum - 1].pnum);
    strcpy(c, List[inputnum - 1].email);

    printf("�ѱ��̸��� �Է��ϼ��� : ");
    scanf("%s", &b);
    printf("����ȣ�� �Է��ϼ��� : ");
    scanf("%s", &c);
    printf("�̸����� �Է��ϼ��� : ");
    scanf("%s", &d);

    for (int i = 0; i < listnum; i++)
    {
        if ((strcmp(List[inputnum - 1].name, List[i].name) == 0) && (strcmp(List[inputnum - 1].pnum, List[i].pnum) == 0))
        {
            printf(" ������ ����� �̹� �ֽ��ϴ�. ");
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
    printf("������ ���Թ�ȣ�� �������� : ");
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
        printf("���Ͽ��½���");
        return -1;
    }

    for (int i = 0; i < listnum; i++)
    {
        fprintf(fp, "���Թ�ȣ : %d\n", List[i].num);
        fprintf(fp, "�ѱ��̸� : %s\n", List[i].name);
        fprintf(fp, "���ѹ� : %s\n", List[i].pnum);
        fprintf(fp, "�̸��� : %s\n", List[i].email);
        fprintf(fp, "==================================\n");
    }

    fclose(fp);
}

void OpenFile() {
    FILE* ofp;

    ofp = fopen("card_data.txt", "rt");

    printf("\n �ؽ�Ʈ ���Ͽ� ����� ���� ���� \n\n");

    for (int i = 0; i < 50; i++)
    {
        fscanf(ofp, "���Թ�ȣ : %d\n", &List[i].num);
        fscanf(ofp, "�ѱ��̸� : %s\n", &List[i].name);
        fscanf(ofp, "���ѹ� : %s\n", &List[i].pnum);
        fscanf(ofp, "�̸��� : %s\n", &List[i].email);
        fscanf(ofp, "==================================\n");
    }

    fclose(ofp);

    listnum = List->num+1;

    show_all_cards();

    system("pause");
    system("cls");
    
}

// �����Լ�
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
            printf("���� ��ȣ�� �Է��ϼ���");
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