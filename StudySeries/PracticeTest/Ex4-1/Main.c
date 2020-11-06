#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif if // _MSC_VER

#include <stdio.h>
#include <stdlib.h>


typedef struct node
{
	double num;
	struct node* next;
} Node;

void insertNode(Node* head, double c);

int main(void)
{
	Node* head, * current;
	head = (Node*)malloc(sizeof(Node));
	head->next = NULL;

	while (1)
	{
		insertNode(head, 10.0);
	}

	free(head);
}

void insertNode(Node* head, double c)
{
	Node* a = (Node*)malloc(sizeof(Node));
	Node* current;
	a->num = c;
	a->next = NULL;
	current = head->next;

	if (head->next == NULL)
	{
		current->next = a;
	}

	else
	{
		while (current->next != NULL)
		{
			current = current->next;
		}
		current->next = a;
	}

	printf("%lf", a->num);
}