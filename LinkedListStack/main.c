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

typedef int element;

typedef struct LinkStack {
    int data;
    struct LinkStack* Link;
} LinkStack;

LinkStack* top;

int isEmpty()
{
    if (top == NULL)
        return 1;
    else
        return 0;
}

void push(element item)
{
    LinkStack* temp = (LinkStack*)malloc(sizeof(LinkStack));
    temp->data = item;
    temp->Link = top;
    top = temp;
}

element pop()
{
    element item;
    LinkStack* temp = top;
    if (isEmpty())
        return;
    else
    {
        item = temp->data ;
        top = temp->Link ;
        free(temp);
        return item;
    }
}

element peek()
{
    LinkStack* temp = top;

    if (isEmpty())
    {
        return;
    }

    else
    {
        return temp->data;
    }
}

void printStack()
{
    LinkStack* p = top;
    printf("\n Stack [ ");
    while (p)
    {
        printf("%d ", p->data);
        p = p->Link;
    }
    printf(" ]");
}
// �����Լ�
int main(void) 
{
    element item;
    top = NULL;
    printf("\n** ���� ���� ���� **\n");
    printStack();
    push(1);    printStack();       // 1 ����
    push(2);    printStack();       // 2 ����
    push(3);    printStack();       // 3 ����

    item = peek(); printStack();    // ���� top�� ���� ���
    printf("peek => %d", item);

    item = pop();  printStack();    // ����
    printf("\t pop  => %d", item);

    item = pop();  printStack();    // ����
    printf("\t pop  => %d", item);

    item = pop();  printStack();    // ����
    printf("\t pop  => %d", item);

	system("pause");
	return EXIT_SUCCESS;
}