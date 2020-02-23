
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Linked {
    int num;
    char name[30];
    char pnum[30];
    char email[30];
    struct Linked* link;
} Linked;

Linked* List;

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
    Linked* temp = (Linked*)malloc(sizeof(Linked));

    temp->num = ++listnum;

    printf("�ѱ��̸��� �Է��ϼ��� : ");
    scanf("%s", temp->name);
    printf("����ȣ�� �Է��ϼ��� : ");
    scanf("%s", temp->pnum);
    printf("�̸����� �Է��ϼ��� : ");
    scanf("%s", temp->email);
    

    //for (int i = 0; i < listnum; i++)
    //{
    //    if ((strcmp(List[listnum].name, List[i].name) == 0) && (strcmp(List[listnum].pnum, List[i].pnum) == 0))
    //    {
    //        printf(" ������ ����� �̹� �ֽ��ϴ�. ");
    //        check = 1;
    //        system("pause");
    //    }
    //}

    if (check == 0)
    {
        temp->link = List;
        List = temp;
    }

    system("cls");
}

void show_all_cards() {

    Linked* temp;
    temp = (Linked*)malloc(sizeof(Linked));
    temp = List;

    while(temp)
    {
        printf("======================\n");
        printf("���Թ�ȣ : %d\n", temp->num);
        printf("�ѱ��̸� : %s\n", temp->name);
        printf("���ѹ� : %s\n", temp->pnum);
        printf("�̸��� : %s\n", temp->email);
        printf("======================\n");

        temp = temp->link;
    }

}

void search_business_card(int num) {

    Linked* temp;
    temp = (Linked*)malloc(sizeof(Linked));
    temp = List;
    while (temp)
    {
        if (num == temp->num)
        {
            printf("==================================\n");
            printf("���Թ�ȣ : %d\n", temp->num);
            printf("�ѱ��̸� : %s\n", temp->name);
            printf("���ѹ� : %s\n", temp->pnum);
            printf("�̸��� : %s\n", temp->email);
            printf("==================================\n");
        }
        temp = temp->link;
    }
}

void edit_business_card() {
    int inputnum;
    int check = 0;
    //char b[30], c[30], d[30];
    Linked* temp;
    temp = (Linked*)malloc(sizeof(Linked));
    temp = List;

    printf(" ���Թ�ȣ �Է� : ");
    scanf("%d", &inputnum);

    
    //strcpy(b, List[inputnum - 1].name);
    //strcpy(c, List[inputnum - 1].pnum);
    //strcpy(c, List[inputnum - 1].email);

    while (temp) {

        if (inputnum == temp->num)
        {
            printf("�ѱ��̸��� �Է��ϼ��� : ");
            scanf("%s", temp->name);
            printf("����ȣ�� �Է��ϼ��� : ");
            scanf("%s", temp->pnum);
            printf("�̸����� �Է��ϼ��� : ");
            scanf("%s", temp->email);
        }
        temp = temp->link;
    }
    //printf("�ѱ��̸��� �Է��ϼ��� : ");
    //scanf("%s", &b);
    //printf("����ȣ�� �Է��ϼ��� : ");
    //scanf("%s", &c);
    //printf("�̸����� �Է��ϼ��� : ");
    //scanf("%s", &d);

    //for (int i = 0; i < listnum; i++)
    //{
    //    if ((strcmp(List[inputnum - 1].name, List[i].name) == 0) && (strcmp(List[inputnum - 1].pnum, List[i].pnum) == 0))
    //    {
    //        printf(" ������ ����� �̹� �ֽ��ϴ�. ");
    //        check = 1;
    //        system("pause");
    //    }
    //}

    //if (check == 0)
    //{
    //    strcpy(List[inputnum - 1].name, b);
    //    strcpy(List[inputnum - 1].pnum, c);
    //    strcpy(List[inputnum - 1].email, d);
    //}
}

void delete_business_card() {
    int del;
    Linked* temp;
    temp = List;
    show_all_cards();
    printf("������ ���Թ�ȣ�� �������� : ");
    scanf("%d", &del);
    
    while (temp) {

        if (temp->num == del+1)
        {
            temp->link = temp->link->link;
            listnum--;
        }
        temp = temp->link;
    }

    temp = List;

    while (temp) {
        if (temp->num > del)
        {
            --(temp->num);
        }
        temp = temp->link;
    }
    free(temp);
}

void NewSave() {

    FILE* fp = fopen("card_data.txt", "wt");
    Linked* temp;
    temp = List;

    if (fp == NULL) {
        printf("���Ͽ��½���");
        return -1;
    }

    while(temp)
    {
        fprintf(fp, "���Թ�ȣ : %d\n", temp->num);
        fprintf(fp, "�ѱ��̸� : %s\n", temp->name);
        fprintf(fp, "���ѹ� : %s\n", temp->pnum);
        fprintf(fp, "�̸��� : %s\n", temp->email);
        fprintf(fp, "==================================\n");
        temp = temp->link;
    }

    fclose(fp);
}

void OpenFile() {

    FILE* ofp;
    Linked* temp;
    Linked* head;
    head = (Linked*)malloc(sizeof(Linked));
    head->link = NULL;
    temp = (Linked*)malloc(sizeof(Linked));
    temp->link = head->link;
    ofp = fopen("card_data.txt", "rt");
    int a;


    printf("\n �ؽ�Ʈ ���Ͽ� ����� ���� ���� \n\n");


    //while (!feof(f)) {
    //    c->next = (card*)malloc(sizeof(card));
    //    c = c->next;
    //    fscanf(f, "%s ", c->name);
    //    fscanf(f, "%s ", c->com);
    //    fscanf(f, "%s ", c->Pnum);
    //    c->next = NULL;

    //    if (strcmp(c->name, t->name) == 0) {
    //        free(c);
    //        free(t);
    //        head->next = NULL;
    //    }
    //}

    while (!feof(ofp)) 
    {
        temp = (Linked*)malloc(sizeof(Linked));
        temp = temp->link;
        fscanf(ofp, "���Թ�ȣ : %d\n", &temp->num);
        fscanf(ofp, "�ѱ��̸� : %s\n", &temp->name);
        fscanf(ofp, "���ѹ� : %s\n", &temp->pnum);
        fscanf(ofp, "�̸��� : %s\n", &temp ->email);
        fscanf(ofp, "==================================\n");
        temp->link = NULL;
    }



    fclose(ofp);
    free(head);
    free(temp);
    
    listnum = List->num + 1;

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
            printf("���� ��ȣ�� �Է��ϼ��� : ");
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