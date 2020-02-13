#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER
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

//1.	자기참조 구조체(명칭 NODE) 를 통해서 연결 리스트를 만들고, 데이터는 실수를 담을 수 있도록 한다.
//여기서 insertNode() 함수로 제일마지막에 새 NODE 를 추가, deleteNode(int index)로 원하는 위치의 값을 삭제하게 한다.
//각 작업 후 노드의 갯수만큼 데이터를 출력하는 함수 printNode()를 구현한다


typedef struct node
{
    int nWn;
    double num;
    struct node* next;
} Node;

int deleteNode(int index);
Node* insertNode(Node* head, double c);
void printNode(Node* head, int index);

// 메인함수
int main(void)
{
    double c;
    int index = 0;
    Node* a;

    a = (Node*)malloc(sizeof(Node));

    Node* head, * current;
    head = (Node*)malloc(sizeof(Node));
    head->next = NULL;

    while (1)
    {
        printf("데이터를 입력하세요 (50이면 종료), (80이면 삭제): ");
        scanf("%lf", &c);

        if (c == 50)
        {
            break;
        }

        if (c == 80)
        {
            deleteNode(index);
        }

        a = insertNode(head, c);

        printNode(a, a->nWn);

    }

    free(a);
    free(head);

    system("pause");
    return EXIT_SUCCESS;
}

Node* insertNode(Node* head, double c)
{
    int pp = 1;

    Node* b = (Node*)malloc(sizeof(Node));
    Node* current;
    Node* fin;
    b->num = c;
    b->next = NULL;
    b->nWn = pp;
    current = head->next;

    if (head->next == NULL)
    {
        head->next = b;
        fin = b;
    }

    else
    {
        while (current->next != NULL)
        {
            current = current->next;
            pp++;
        }
        current->next = b;
        fin = current->next;
        pp++;
    }

    fin->nWn = pp;
    return fin;
}

int deleteNode(int index)
{
    //Node* b = (Node*)malloc(sizeof(Node));
    //Node* current;
    //int del;

    //printf("삭제할 노드 위치를 적으세요 : ");
    //scanf("%d", del);

    //if (index > del)
    //{

    //}
}

void printNode(Node* head, int index)
{
    printf("노드의 갯수 : %d\n", index);
    printf("%.1lf\n", head->num);
}