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

//typedef int element;
//
//typedef struct LinkStack {
//    int data;
//    struct LinkStack* Link;
//} LinkStack;
//
//LinkStack* top;
//
//int isEmpty()
//{
//    if (top == NULL)
//        return 1;
//    else
//        return 0;
//}
//
//void push(element item)
//{
//    LinkStack* temp = (LinkStack*)malloc(sizeof(LinkStack));
//    temp->data = item;
//    temp->Link = top;
//    top = temp;
//}
//
//element pop()
//{
//    element item;
//    LinkStack* temp = top;
//    if (isEmpty())
//        return;
//    else
//    {
//        item = temp->data ;
//        top = temp->Link ;
//        free(temp);
//        return item;
//    }
//}
//
//element peek()
//{
//    LinkStack* temp = top;
//
//    if (isEmpty())
//    {
//        return;
//    }
//
//    else
//    {
//        return temp->data;
//    }
//}
//
//void printStack()
//{
//    LinkStack* p = top;
//    printf("\n Stack [ ");
//    while (p)
//    {
//        printf("%d ", p->data);
//        p = p->Link;
//    }
//    printf(" ]");
//}
//// 메인함수
//int main(void) 
//{
//    element item;
//    top = NULL;
//    printf("\n** 연결 스택 연산 **\n");
//    printStack();
//    push(1);    printStack();       // 1 삽입
//    push(2);    printStack();       // 2 삽입
//    push(3);    printStack();       // 3 삽입
//
//    item = peek(); printStack();    // 현재 top의 원소 출력
//    printf("peek => %d", item);
//
//    item = pop();  printStack();    // 삭제
//    printf("\t pop  => %d", item);
//
//    item = pop();  printStack();    // 삭제
//    printf("\t pop  => %d", item);
//
//    item = pop();  printStack();    // 삭제
//    printf("\t pop  => %d", item);
//
//	system("pause");
//	return EXIT_SUCCESS;
//}

typedef int element;

typedef struct StackLink {
    int index;
    int number;
    struct StackLink* link;
} StackLink;

StackLink* top;
int a = 0;
int isEmpty() {
    if (top == NULL)
    {
        return 1;
    }

    else
        return 0;
}

void push(element item) {
    StackLink* temp;
    temp = (StackLink*)malloc(sizeof(StackLink));
    temp->number = item;
    temp->link = top;
    temp->index = a;
    a++;
    top = temp;
}

element pop() {
    element item;
    StackLink* temp;
    temp = top;
    if (isEmpty())
    {
        printf("NO");
        return;
    }

    else
    {
        item = temp->number;
        top = temp->link;
        free(temp);
        return item;
    }
}

element peek() {
    element item;
    if (isEmpty())
    {
        printf("X");
        return 0 ;
    }

    else
    {
        item = top->number;
        return item;
    }
}
//void printStack() {
//    element item;
//    StackLink* p;
//    p = top;
//    int bb[80];
//
//    printf("\n Stack [ ");
//
//    if (top !=NULL)
//    {
//        while (p)
//        {
//            bb[p->index] = p->number;
//            p = p->link;
//        }
//
//        for (int i = 0; i <= top->index; i++)
//        {
//            printf("%d", bb[i]);
//        }
//
//    }
//
//
//    //while (p) {
//    //    item = p->number;
//    //    printf("%d ", item);
//    //    p = p->link;
//    //}
//    printf(" ]");
//}

void printStack() {
    StackLink* p;
    p = top;
    int b[80];
    printf("\n stack [");

    if (top != NULL)
    {
        while (p)
        {
            b[p->index] = p->number;
            p = p->link;
        }

        for (int i = 0; i <= top->index; i++)
        {
            printf("%d", b[i]);
        }
    }
    printf("]");
    
}

int main(void) {
    element item;
    top = NULL;

    printStack();
    push(1); printStack();
    push(2); printStack();
    push(3); printStack();

    item = peek(); printStack();
    printf(" peek ==> %d", item);

    item = pop(); printStack();
    printf(" peek ==> %d", item);

    item = pop(); printStack();
    printf(" peek ==> %d", item);

    item = pop(); printStack();
    printf(" peek ==> %d", item);
}