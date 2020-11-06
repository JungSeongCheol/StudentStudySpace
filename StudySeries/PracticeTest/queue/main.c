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

#define MAX_Size 4
typedef char element;

typedef struct QueueType {
    element queue[MAX_Size];
    int front, rear;
} QueueType;

QueueType* createQueue() {
    QueueType* Q;
    Q = (QueueType*)malloc(sizeof(QueueType));
    Q->front = -1;
    Q->rear = -1;
}

int isEmpty(QueueType* Q) {
    if (Q->front == Q->rear)
    {
        return 1;
    }

    else
        return 0;
}

int isfull(QueueType* Q) {
    if (Q->rear == MAX_Size - 1)
    {
        return 1;
    }

    return 0;
}

void enQueue(QueueType* Q,element item) {
    if (isfull(Q))
    {
        printf("~~");
        return;
    }

    else {
        Q->rear++;
        Q->queue[Q->rear] = item;
    }
}

element deQueue(QueueType* Q) {
    if (isEmpty(Q))
    {
        printf("~~");
        return;
    }

    else
    {
        Q->front++;
        return Q->queue[Q->front];
    }
}

element peek(QueueType* Q) {
    if (isEmpty(Q))
    {

    }

    else
        return Q->queue[Q->front + 1];
}

void printQ(QueueType* Q) {
    int i;
    printf(" Queue : [");
    for (i = Q->front+1; i <= Q->rear; i++)
    {
        printf("%3c", Q->queue[i]);
    }
    printf("]");
}

int main(void) 
{
    QueueType* Q1 = createQueue();  // 큐 생성
    element data;
    printf("\n ***** 순차 큐 연산 ***** \n");
    printf("\n 삽입 A>>");  enQueue(Q1, 'A'); printQ(Q1);
    printf("\n 삽입 B>>");  enQueue(Q1, 'B'); printQ(Q1);
    printf("\n 삽입 C>>");  enQueue(Q1, 'C'); printQ(Q1);
    data = peek(Q1);    printf(" peek item : %c \n", data);
    printf("\n 삭제  >>");  data = deQueue(Q1); printQ(Q1);
    printf("\t삭제 데이터: %c", data);
    printf("\n 삭제  >>");  data = deQueue(Q1); printQ(Q1);
    printf("\t삭제 데이터: %c", data);
    printf("\n 삭제  >>");  data = deQueue(Q1); printQ(Q1);
    printf("\t\t삭제 데이터: %c", data);

    printf("\n 삽입 D>>");  enQueue(Q1, 'D'); printQ(Q1);
    printf("\n 삽입 E>>");  enQueue(Q1, 'E'); printQ(Q1);
}