
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
    printf("1번 : 입력\n");
    printf("2번 : 수정\n");
    printf("3번 : 삭제\n");
    printf("4번 : 전체출력\n");
    printf("5번 : 검색\n");
    printf("6번 : 종료\n");
}

void input_business_card() {
    int check = 0;
    Linked* temp = (Linked*)malloc(sizeof(Linked));

    temp->num = ++listnum;

    printf("한국이름을 입력하세요 : ");
    scanf("%s", temp->name);
    printf("폰번호를 입력하세요 : ");
    scanf("%s", temp->pnum);
    printf("이메일을 입력하세요 : ");
    scanf("%s", temp->email);
    

    //for (int i = 0; i < listnum; i++)
    //{
    //    if ((strcmp(List[listnum].name, List[i].name) == 0) && (strcmp(List[listnum].pnum, List[i].pnum) == 0))
    //    {
    //        printf(" 동일한 사람이 이미 있습니다. ");
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
        printf("명함번호 : %d\n", temp->num);
        printf("한국이름 : %s\n", temp->name);
        printf("폰넘버 : %s\n", temp->pnum);
        printf("이메일 : %s\n", temp->email);
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
            printf("명함번호 : %d\n", temp->num);
            printf("한국이름 : %s\n", temp->name);
            printf("폰넘버 : %s\n", temp->pnum);
            printf("이메일 : %s\n", temp->email);
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

    printf(" 명함번호 입력 : ");
    scanf("%d", &inputnum);

    
    //strcpy(b, List[inputnum - 1].name);
    //strcpy(c, List[inputnum - 1].pnum);
    //strcpy(c, List[inputnum - 1].email);

    while (temp) {

        if (inputnum == temp->num)
        {
            printf("한국이름을 입력하세요 : ");
            scanf("%s", temp->name);
            printf("폰번호를 입력하세요 : ");
            scanf("%s", temp->pnum);
            printf("이메일을 입력하세요 : ");
            scanf("%s", temp->email);
        }
        temp = temp->link;
    }
    //printf("한국이름을 입력하세요 : ");
    //scanf("%s", &b);
    //printf("폰번호를 입력하세요 : ");
    //scanf("%s", &c);
    //printf("이메일을 입력하세요 : ");
    //scanf("%s", &d);

    //for (int i = 0; i < listnum; i++)
    //{
    //    if ((strcmp(List[inputnum - 1].name, List[i].name) == 0) && (strcmp(List[inputnum - 1].pnum, List[i].pnum) == 0))
    //    {
    //        printf(" 동일한 사람이 이미 있습니다. ");
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
    printf("삭제할 명함번호를 넣으세요 : ");
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
        printf("파일오픈실패");
        return -1;
    }

    while(temp)
    {
        fprintf(fp, "명함번호 : %d\n", temp->num);
        fprintf(fp, "한국이름 : %s\n", temp->name);
        fprintf(fp, "폰넘버 : %s\n", temp->pnum);
        fprintf(fp, "이메일 : %s\n", temp->email);
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


    printf("\n 텍스트 파일에 저장된 명함 정보 \n\n");


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
        fscanf(ofp, "명함번호 : %d\n", &temp->num);
        fscanf(ofp, "한국이름 : %s\n", &temp->name);
        fscanf(ofp, "폰넘버 : %s\n", &temp->pnum);
        fscanf(ofp, "이메일 : %s\n", &temp ->email);
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
            printf("명함 번호를 입력하세요 : ");
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