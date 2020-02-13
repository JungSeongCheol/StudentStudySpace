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
    double num;
    struct node* next;
} Node;

int deleteNode(int index);
int insertNode(Node* head, double c);
void printNode(Node* head, int index);

// �����Լ�
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

        index = insertNode(head, c);

        printf("����� ���� : %d\n ", index);
        
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

    printf("������ ��� ��ġ�� �������� : ");
    scanf("%d", del);

    if (index > del)
    {
        
    }
}

void printNode(Node* head, int index)
{

    printf("%.1lf\t", head->num);
}

