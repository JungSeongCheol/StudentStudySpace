/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, 구조체 포인터 학습
  --------------------------------------------------------------------------------
  first created - 2020.02.07
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//struct score
//{
//    int kor;
//    int eng;
//    int mat;
//};
//
//// 메인함수
//int main(void) 
//{
//    struct score yuni = { 90, 80, 70 };
//    struct score* ps = &yuni;
//
//    printf("국어 : %d\n", (*ps).kor);
//    printf("영어 : %d\n", ps->eng);
//    printf("수학 : %d\n", ps->mat);
//	system("pause");
//	return EXIT_SUCCESS;
//}

//struct address
//{
//    char name[20];
//    int age;
//    char tel[20];
//    char addr[80];
//};
//
//int main(void)
//{
//    struct address list[5] = {
//        {"홍길동", 23, "111-1111", "울릉도 독도"},
//        {"이순신", 35, "222-2222", "서울 건천동"},
//        {"장보고", 15, "333-3333", "완도 청해진"},
//        {"유관순", 15, "444-4444", "충남 천안"},
//        {"안중근", 45, "555-5555", "황해도 해주"}
//    };
//
//    for (int i = 0; i < 5; i++)
//    {
//        printf("%10s%5d%15s%20s\n", list[i].name, list[i].age, list[i].tel, list[i].addr);
//    }
//
//    system("pause");
//    return EXIT_SUCCESS;
//}

//void print_list(struct address* lp);
//
//struct address
//{
//    char name[20];
//    int age;
//    char tel[20];
//    char addr[80];
//};
//
//int main(void)
//{
//    struct address list[5] = {
//        {"홍길동", 23, "111-1111", "울릉도 독도"},
//        {"이순신", 35, "222-2222", "서울 건천동"},
//        {"장보고", 15, "333-3333", "완도 청해진"},
//        {"유관순", 15, "444-4444", "충남 천안"},
//        {"안중근", 45, "555-5555", "황해도 해주"}
//    };
//
//    print_list(list);
//
//    system("pause");
//    return EXIT_SUCCESS;
//}
//
//void print_list(struct address* lp)
//{
//    for (int i = 0; i < 5; i++)
//    {
//        printf("%10s%5d%15s%20s\n", (lp + i)->name, (lp + i)->age, (lp + i)->tel, (lp + i)->addr);
//    }
//}

//struct address
//{
//    char name[20];
//    int age;
//    char tel[20];
//    char addr[80];
//};
//
//void print_list(struct address* ls);
//
//int main(void)
//{
//    struct address list1[5] = {
//    {"홍길동", 23, "111-1111", "울릉도 독도"},
//    {"이순신", 35, "222-2222", "서울 건천동"},
//    {"장보고", 15, "333-3333", "완도 청해진"},
//    {"유관순", 15, "444-4444", "충남 천안"},
//    {"안중근", 45, "555-5555", "황해도 해주"}
//    };
//
//    print_list(list1);
//
//    system("pause");
//    return EXIT_SUCCESS;
//}
//
//
//void print_list(struct address *ls)
//{
//    for (int i = 0; i < 5; i++)
//    {
//        printf("%10s%5d%15s%20s\n", (*(ls+i)).name, ls[i].age, (ls+i)->tel, ls[i].addr);
//    }
//}

struct list
{
    int num;
    struct list* next;
};

int main(void)
{
    struct list a = { 10, 0 }, b = { 20, 0 }, c = { 30,0 };
    struct list* head = &a, *current;

    a.next = &b;
    b.next = &c;

    printf("head->num : %d\n", head->num);
    printf("head->next->num : %d\n", head->next->num);

    printf("list all : ");
    current = head;

    while (current != NULL)
    {
        printf("%d ", current->num);
        current = current->next;
    }

    printf("\n");
    system("pause");
    return EXIT_SUCCESS;
    
}