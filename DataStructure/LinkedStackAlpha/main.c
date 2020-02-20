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

typedef char element;

typedef struct StackArray {
    int number;
    char data;
    struct StackArray* link;
} StackArray;

StackArray* top;
int index = 0;

int isEmpty() {
    if (top == NULL)
        return 1;
    else
        return 0;
}

void push(int alpha) {

    StackArray* temp;
    temp = (StackArray*)malloc(sizeof(StackArray));
    temp->data = alpha + 64;
    temp->link = top;
    temp->number = index++;
    top = temp;
}

element peek()
{
    if (isEmpty())
    {
        printf("������ ����ֽ��ϴ�.");
        return 0;
    }

    else
    {
        return top->data;
    }
}

element pop()
{
    StackArray* temp;
    temp = top;
    if (isEmpty())
    {
        printf("������ ����ֽ��ϴ�.");
        return 0;
    }

    else
    {
        top = temp->link;
        return temp->data;
        
        free(temp);
    }
}
void printStack() {
    
    StackArray* p;
    char b[80];
    p = top;
    printf("\n STACK [");

    if (top != NULL)
    {
        while (p)
        {
            b[p->number] = p->data;
            p = p->link;
        }

        for (int i = 0 ; i <= top->number; i++)
        {
            printf(" %c", b[i]);
        }
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
    push(1);    printStack();       // 1 ���� (A push)
    push(2);    printStack();       // 2 ���� (B push)
    push(3);    printStack();       // 3 ���� (C push)

    item = peek(); printStack();    // ���� top�� ���� ���
    printf("peek => %c", item);

    item = pop();  printStack();    // ����
    printf("\t pop  => %c", item);

    item = pop();  printStack();    // ����
    printf("\t pop  => %c", item);

    item = pop();  printStack();    // ����
    printf("\t pop  => %c", item);


	return EXIT_SUCCESS;
}