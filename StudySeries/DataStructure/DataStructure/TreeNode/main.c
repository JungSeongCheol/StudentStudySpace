/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

//#include <stdio.h>
//#include <stdlib.h>
//#include <memory.h>
//
//typedef struct treeNode {
//    char data;
//    struct treeNode* left;
//    struct treeNode* right;
//} treeNode;
//
//treeNode* makeRootNode(char data, treeNode* leftNode, treeNode* rightNode) {
//    treeNode* root = (treeNode*)malloc(sizeof(treeNode));
//    root->data = data;
//    root->left = leftNode;
//    root->right = rightNode;
//    return root;
//}
//
//void preorder(treeNode* root){
//    if (root)
//    {
//        printf("%c ", root->data);
//        preorder(root->left);
//        preorder(root->right);
//    }
//}
//
//
//void inorder(treeNode* root) {
//    if (root)
//    {
//        inorder(root->left);
//        printf("%c ", root->data);
//        inorder(root->right);
//    }
//}
//
//void postorder(treeNode* root) {
//    if (root)
//    {
//        postorder(root->left);
//        postorder(root->right);
//        printf("%c ",root->data);
//    }
//}
//
//int main(void) 
//{
//    treeNode* n11 = makeRootNode('K', NULL, NULL);
//    treeNode* n10 = makeRootNode('J', NULL, NULL);
//    treeNode* n9 = makeRootNode('I', NULL, NULL);
//    treeNode* n8 = makeRootNode('H', NULL, NULL);
//    treeNode* n7 = makeRootNode('G', NULL, n11);
//    treeNode* n6 = makeRootNode('F', NULL, NULL);
//    treeNode* n5 = makeRootNode('E', n6, n10);
//    treeNode* n4 = makeRootNode('D', n8, NULL);
//    treeNode* n3 = makeRootNode('C', n6, n7);
//    treeNode* n2 = makeRootNode('B', n4, n5);
//    treeNode* n1 = makeRootNode('A', n2, n3);
//
//    printf("\n preorder : ");
//    preorder(n1);
//
//    printf("\n inorder : ");
//    inorder(n1);
//
//    printf("\n postorder : ");
//    inorder(n1);
//
//    system("pause");
//    return EXIT_SUCCESS;
//}

#include <stdio.h>
#include <stdlib.h>

typedef struct TreeNode {
    char data;
    struct TreeNode* left;
    struct TreeNode* right;
} TreeNode;

TreeNode* MakeTreeNode(char data, TreeNode* leftNode, TreeNode* rightNode) {

    TreeNode* root = (TreeNode*)malloc(sizeof(TreeNode));
    root->data = data;
    root->left = leftNode;
    root->right = rightNode;

    return root;
}

void preorder(TreeNode* node) {
    if (node)
    {
        printf("%c", node->data);
        preorder(node->left);
        preorder(node->right);
    }
}

int main(void)
{
    TreeNode* N7 = MakeTreeNode('D', NULL, NULL);
    TreeNode* N6 = MakeTreeNode('C', NULL, NULL);
    TreeNode* N5 = MakeTreeNode('B', NULL, NULL);
    TreeNode* N4 = MakeTreeNode('A', NULL, NULL);
    TreeNode* N3 = MakeTreeNode('/', N6, N7);
    TreeNode* N2 = MakeTreeNode('*', N4, N5);
    TreeNode* N1 = MakeTreeNode('-', N2, N3);

    preorder(N1);
}