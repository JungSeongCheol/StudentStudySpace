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

typedef struct dlr {
    char data;
    struct dlr* left;
    struct dlr* right;
}dlr;

typedef struct TreeNode {
    char A;

} TreeNode;

dlr* CreateNode(char data, dlr* leftNode, dlr* rightNode) {
    dlr* root = (dlr*)malloc(sizeof(dlr));
    root->data = data;
    root->left = leftNode;
    root->right = rightNode;
}

void inorder(dlr* Stack) {
    if (true)
    {

    }
}


// 메인함수
int main(void) 
{
    dlr 
	printf("Hello World!\n");
    // type here.
	system("pause");
	return EXIT_SUCCESS;
}