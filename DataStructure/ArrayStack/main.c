/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

//#include <stdio.h>
//#include <stdlib.h>

//#include <stdio.h>
//#include <stdlib.h>
//
//#define Stack_Size 100
//
//typedef int element;
//int top = -1;
//element stack[Stack_Size];
//
//int isEmpty()
//{
//    if (top == -1)
//        return 1;
//    else
//        return 0;
//}
//
//int isFull()
//{
//    if (top == Stack_Size - 1)
//        return 1;
//    else
//        return 0;
//}
//
//void push(element item)
//{
//    if (isFull())
//    {
//        printf("STack is FULL\n");
//        return;
//    }
//
//    else
//    {
//        stack[++top] = item;
//    }
//}
//
//element pop()
//{
//    if (isEmpty())
//    {
//        printf("스택이 비어있습니다.");
//        return;
//    }
//
//    else
//        return stack[top--];
//}
//
//element peek()
//{
//    if (isEmpty())
//    {
//        printf("스택이 비어있습니다.");
//        exit(1);
//    }
//
//    else
//        return stack[top];
//}
//
//void printStack()
//{
//    printf("\n STACK [ ");
//    for (int i = 0; i <= top; i++)
//    {
//        printf("%d ", stack[i]);
//    }
//    printf("]");
//}
//
//int main(void)
//{
//    element item;
//    printf("\n** 순차 스택 연산 **\n");
//    printStack();
//    push(1); printStack();
//    push(2); printStack();
//    push(3); printStack();
//
//    item = peek(); printStack();
//    printf("peek ==> %d", item);
//    
//    item = pop(); printStack();
//    printf("\tpop ==> %d", item);
//
//    item = pop(); printStack();
//    printf("\tpop ==> %d", item);
//
//    item = pop(); printStack();
//    printf("\tpop ==> %d", item);
//}

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef int element;

typedef struct stackNode {
    element data;
    struct stackNode* link;
} stackNode;

stackNode* top;

int isEmpty()
{
    if (top == NULL)
    {
        return 1;
    }
    return 0;
}

void push(element item)
{
    stackNode* temp = (stackNode*)malloc(sizeof(stackNode));
    temp->data = item;
    temp->link = top;
    top = temp;
}

element pop()
{
    element item;
    stackNode* temp = top;

    if (top == NULL)
    {
        printf("\n\n Stack is empty!\n");
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

element peek() {
    if (top == NULL)
    {
        printf("\n\n Stack is empty!\n");
        return 0;
    }

    else
    {
        return(top->data);
    }
}

void printStack() {
    stackNode* p = top;
    printf("\n STACK [ ");
    while (p)
    {
        printf("%d ", p->data);
        p = p->link;
    }

    printf("]");
}

void main(void)
{
    element item;
    top = NULL;
    printf("\n** 연결 스택 연산 **\n");
    printStack();
    push(1); printStack();
    push(2); printStack();
    push(3); printStack();

    item = peek(); printStack();
    printf("  peek => %d", item);

    item = pop(); printStack();
    printf("\t  pop => %d", item);

    item = pop(); printStack();
    printf("\t  pop => %d", item);

    item = pop(); printStack();
    printf("\t  pop => %d\n", item);

    system("pause");
    return EXIT_SUCCESS;
}