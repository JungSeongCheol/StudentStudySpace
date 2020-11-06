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

#define MAX_VERTEX 10
#define FALSE 0
#define TRUE 1

typedef struct graphNode {
    int vertex;
    struct graphNode* link;
} graphNode;

typedef struct graphType {
    int n;
    graphNode* adjList_H[MAX_VERTEX];
    int visited[MAX_VERTEX];
} graphType;

typedef int element;

typedef struct stackNode {
    int data;
    struct stackNode* link;
} stackNode;

stackNode* top;

int isEmpty() {
    if (top == NULL)
    {
        return 1;
    }
    return 0;
}

void push(int item) {
    stackNode* temp;
    temp = (stackNode*)malloc(sizeof(stackNode));
    temp->data = item;
    temp->link = top;
    top = temp;
}

int pop() {
    int item;
    stackNode* temp;
    temp = top;

    if (isEmpty())
    {
        printf("스택이 비어있습니다.");
        return 0;
    }

    else
    {
        item = temp->data;
        top = temp->link;
        free(temp);
        return item;
    }
} //==> 스택 마무리

void creatGraph(graphType* g) {
    int v;
    g->n = 0;
    for (v = 0; v < MAX_VERTEX; v++)
    {
        g->visited[v] = FALSE;
        g->adjList_H[v] = NULL;
    }
}

void insertVertex(graphType* g, int v)
{

}



int main(void) 
{
    top = NULL;
	system("pause");
	return EXIT_SUCCESS;
}