/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

//#include <stdio.h>
//#include <stdlib.h>
//#include <string.h>

//typedef int element;
//
//typedef struct stackNode {
//    element data;
//    struct stackNode* link;
//} stackNode;
//
//stackNode* top;
//
//int isEmpty()
//{
//    if (top == NULL)
//    {
//        return 1;
//    }
//    return 0;
//}
//
//void push(element item)
//{
//    stackNode* temp = (stackNode*)malloc(sizeof(stackNode));
//    temp->data = item;
//    temp->link = top;
//    top = temp;
//}
//
//element pop()
//{
//    element item;
//    stackNode* temp = top;
//
//    if (top == NULL)
//    {
//        printf("\n\n Stack is empty!\n");
//        return 0;
//    }
//
//    else
//    {
//        item = temp->data;
//        top = temp->link;
//        free(temp);
//        return item;
//    }
//}
//
//element peek() {
//
//    if (top == NULL)
//    {
//        printf("\n\n Stack is empty!\n");
//        return 0;
//    }
//
//    else
//    {
//        return(top->data);
//    }
//}
//
//void printStack() {
//    stackNode* p = top;
//    printf("\n STACK [ ");
//    while (p)
//    {
//        printf("%d ", p->data);
//        p = p->link;
//    }
//
//    printf("]");
//}
//
//void main(void)
//{
//    element item;
//    top = NULL;
//    printf("\n** ���� ���� ���� **\n");
//    printStack();
//    push(1); printStack();
//    push(2); printStack();
//    push(3); printStack();
//
//    item = peek(); printStack();
//    printf("  peek => %d", item);
//
//    item = pop(); printStack();
//    printf("\t  pop => %d", item);
//
//    item = pop(); printStack();
//    printf("\t  pop => %d", item);
//
//    item = pop(); printStack();
//    printf("\t  pop => %d\n", item);
//
//    system("pause");
//    return EXIT_SUCCESS;
//}

#include <stdio.h>
#include <stdlib.h>;
#include <string.h>;

typedef struct listStack {
    int data;
    struct listStack* link;
} listStack;

listStack* top;

int isEmpty()
{
    if (top == NULL)
    {
        return 1;
    }
    else
        return 0;
}

void push(int item)
{
    listStack* temp = (listStack*)malloc(sizeof(listStack));
    temp->data = item;
    temp->link = top;
    top = temp;
}

int pop()
{
    int item;
    listStack* temp = top;

    if (isEmpty())
    {
        printf("������ ����ֽ��ϴ�.");
        return 0;
    }

    else
    {
        item = temp->data;
        top = temp->link;
        free(temp);
        return item;
    }
}

void printStack()
{
    printf("Stack [");

    while(1)

    printf(" ]");
}

void main(void)
{
    int item;
    top = NULL;
    printf("\n** ���� ���� ���� **\n");
    printStack();
    push(1);    printStack();       // 1 ����
    push(2);    printStack();       // 2 ����
    push(3);    printStack();       // 3 ����

    //item = peek(); printStack();    // ���� top�� ���� ���
    //printf("peek => %d", item);

    item = pop();  printStack();    // ����
    printf("\t pop  => %d", item);

    item = pop();  printStack();    // ����
    printf("\t pop  => %d", item);

    item = pop();  printStack();    // ����
    printf("\t pop  => %d", item);
}