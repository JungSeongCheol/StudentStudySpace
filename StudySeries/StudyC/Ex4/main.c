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
    double num;
    struct node* next;
} Node;

int deleteNode(int index);
int insertNode(Node* head, double c);
void printNode(Node* head, int index);

// 메인함수
int main(void) 
{
    double c;
    int index;
    Node *a;
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

        index = insertNode(head, c);

        printf("노드의 갯수 : %d\n ", index);
        
    }
    
    free(a);
    free(head);

	system("pause");
	return EXIT_SUCCESS;
}

int insertNode(Node *head, double c)
{
    int pp = 1;

    Node* b = (Node*)malloc(sizeof(Node));
    Node* current;
    b->num = c;
    b->next = NULL;
    current = head->next;

    if (head->next == NULL)
    {
        head->next = b;
    }

    else
    {
        printNode(current, pp);
        while (current->next != NULL)
        {
            current = current->next;
            pp++;
            printNode(current, pp);
        }
        current->next = b;
        pp++;

    }
    printf("%.1lf\n", b->num);
    return pp;
}

int deleteNode(int index)
{
    Node* b = (Node*)malloc(sizeof(Node));
    Node* current;
    int del;

    printf("삭제할 노드 위치를 적으세요 : ");
    scanf("%d", del);

    if (index > del)
    {
        
    }
}

void printNode(Node* head, int index)
{

    printf("%.1lf\t", head->num);
}

