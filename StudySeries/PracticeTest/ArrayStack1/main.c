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
#define Stack_Size 4
typedef int element;

int top = -1;
int Stack[Stack_Size];

int isEmpty() {
    if (top == -1)
    {
        return 1;
    }
    return 0;
}

int isFull() {
    if (top == Stack_Size - 1)
    {
        return 1;
    }

    else
        return 0;
}

void push(element item) {
    if (isFull())
    {
        return;
    }

    else
    {
        Stack[++top] = item;
    }
}

element pop() {
    element item;

    if (isEmpty())
    {
        printf("NO");
        return 0;
    }

    else
    {
        item = Stack[top--];
        return item;
    }
}

element peek() {
    if (isEmpty())
    {
        printf("NO");
        return 0;
    }

    else
        return Stack[top];
}

void printStack() {

    printf("\n Stack [ ");
    for (int i = 0; i <= top; i++)
    {
        printf("%d ", Stack[i]);
    }
    printf(" ]");
}
// 메인함수
int main(void) 
{
    element item;

    printStack();
    push(1); printStack();
    push(2); printStack();
    push(3); printStack();

    item = peek(); printStack();
    printf(" peek ==> %d", item);

    item = pop(); printStack();
    printf(" pop ==> %d", item);

    item = pop(); printStack();
    printf(" pop ==> %d", item);

    item = pop(); printStack();
    printf(" pop ==> %d", item);

	system("pause");
	return EXIT_SUCCESS;
}