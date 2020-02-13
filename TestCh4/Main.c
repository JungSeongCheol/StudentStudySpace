#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER
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

//1.	�ڱ����� ����ü(��Ī NODE) �� ���ؼ� ���� ����Ʈ�� �����, �����ʹ� �Ǽ��� ���� �� �ֵ��� �Ѵ�.
//���⼭ insertNode() �Լ��� ���ϸ������� �� NODE �� �߰�, deleteNode(int index)�� ���ϴ� ��ġ�� ���� �����ϰ� �Ѵ�.
//�� �۾� �� ����� ������ŭ �����͸� ����ϴ� �Լ� printNode()�� �����Ѵ�


typedef struct node
{
    int nWn;
    double num;
    struct node* next;
} Node;

int deleteNode(int index);
Node* insertNode(Node* head, double c);
void printNode(Node* head, int index);

// �����Լ�
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
        printf("�����͸� �Է��ϼ��� (50�̸� ����), (80�̸� ����): ");
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

    //printf("������ ��� ��ġ�� �������� : ");
    //scanf("%d", del);

    //if (index > del)
    //{

    //}
}

void printNode(Node* head, int index)
{
    printf("����� ���� : %d\n", index);
    printf("%.1lf\n", head->num);
}