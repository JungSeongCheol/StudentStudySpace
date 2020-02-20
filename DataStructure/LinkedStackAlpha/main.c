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
        printf("스택이 비어있습니다.");
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
        printf("스택이 비어있습니다.");
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

// 메인함수
int main(void) 
{
    element item;
    top = NULL;

    printf("\n** 순차 스택 연산 **\n");
    printStack();
    push(1);    printStack();       // 1 삽입 (A push)
    push(2);    printStack();       // 2 삽입 (B push)
    push(3);    printStack();       // 3 삽입 (C push)

    item = peek(); printStack();    // 현재 top의 원소 출력
    printf("peek => %c", item);

    item = pop();  printStack();    // 삭제
    printf("\t pop  => %c", item);

    item = pop();  printStack();    // 삭제
    printf("\t pop  => %c", item);

    item = pop();  printStack();    // 삭제
    printf("\t pop  => %c", item);


	return EXIT_SUCCESS;
}