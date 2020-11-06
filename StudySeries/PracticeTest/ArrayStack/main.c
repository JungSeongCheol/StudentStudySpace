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
#include <string.h>
#define Stack_Size 100
// 메인함수

typedef int element;

element stack[Stack_Size];
int top = -1;

int isEmpty()
{
    if (top == -1 )
    {
        return 1;
    }
    else
        return 0;
}

int isFull()
{
    if (top == Stack_Size - 1)
        return 1;
    else
        return 0;
}

void push(element item)
{
    if (isFull())
    {
        return 0;
    }

    else
        stack[++top] = item;
}

element pop()
{

    if (isEmpty())
    {
        printf(" NO ");
        return;
    }
    else
        return stack[top--];
}

element peek()
{

    if (isEmpty())
    {
        printf(" NO ");
        return;
    }
    else
        return stack[top];

}

void printStack()
{
    printf("\n STACK [ ");
    for (int i = 0; i <= top; i++)
    {
        printf("%d ", stack[i]);
    }
    printf(" ]");
}

int main(void) 
{
    element item;
    printf("\n** 순차 스택 연산 **\n");
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