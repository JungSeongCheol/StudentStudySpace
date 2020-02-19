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
// 메인함수
int main(void) 
{
    element item;
    top = NULL;
    printf("\n** 연결 스택 연산 **\n");
    printStack();
    push(1);    printStack();       // 1 삽입
    push(2);    printStack();       // 2 삽입
    push(3);    printStack();       // 3 삽입

    item = peek(); printStack();    // 현재 top의 원소 출력
    printf("peek => %d", item);

    item = pop();  printStack();    // 삭제
    printf("\t pop  => %d", item);

    item = pop();  printStack();    // 삭제
    printf("\t pop  => %d", item);

    item = pop();  printStack();    // 삭제
    printf("\t pop  => %d", item);

	system("pause");
	return EXIT_SUCCESS;
}