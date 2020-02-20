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

typedef struct StackNum{
    int num;
    struct StackNum* link;
} StackNum;

StackNum* top;

int isEmpty() {
    if (top == NULL)
        return 1;
    else
        return 0;
}

void push(int item) {
    StackNum* temp;
    temp = (StackNum*)malloc(sizeof(StackNum));
    temp->num = item;
    temp->link = top;
    top = temp;
}

void printNode(){

    StackNum* p;
    p = top;
    if (isEmpty())
    {
        printf("스택이 비어있습니다.");
        return;
    }
    
    else
    {
        while (p)
        {
            printf("%d ", p->num);
            p = p->link;
        }
    }
}
int main(void) 
{
    int a = 1, b = 2, c = 3, d = 4;
    top = NULL;
    printf("%d %d %d %d", a, b, c, d);
    push(a);
    push(b);
    push(c);
    push(d);    printf("\n");  printNode();

	system("pause");
	return EXIT_SUCCESS;
}