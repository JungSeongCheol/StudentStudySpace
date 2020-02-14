/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수
  --------------------------------------------------------------------------------
  first created - 2020.02.01
  writer - Hugo MG Sung.
*/

//환경: Windows 10 Professional, Visual Studio Community 2019
//개요 : C언어 사용, 윈도우 OS 에서 콘솔 명함관리 프로그램을 만듭니다.명함정보(명함번호, 한글이름, 폰번호, 이메일)의 입력, 수정, 삭제할 수 있는 기능과 추가로 검색을 할 수 있는 기능도 만듭니다.입출력에 대한 기능은 main 함수와 다른 소스에 만듭니다.
//
//1번 문항(30)
//- exam01로 프로젝트 생성.콘솔에서 입출력 기능을 구현
//- 1번 입력, 2번 수정, 3번 삭제, 4번 전체출력, 5번 검색, 6번 종료로 메뉴 표현
//- 구조체 배열을 사용하여 데이터를 관리함.배열의 크기는 상수로 정의(50)
//- 명함정보 입력 함수는 input_business_card()로 정의, 입력시는 한글이름, 폰번호, 이메일만 입력하고, 명함번호는 1에서부터 자동으로 증가

//2번 문항(30)
//- 전체 명함정보를 출력하는 함수는 show_all_cards()로 정의, 명함번호 / 한글이름 / 폰번호 / 이메일 순으로 한줄씩 출력
//- 검색 콘솔에서 명함번호 입력받아, 검색결과를 출력 후 키를 누르면 다시 메뉴를 출력, 함수는 search_business_card(int num)
//- 수정 기능은 edit_business_card()로 명함번호 입력으로 검색 후 폰번호, 이메일을 다시 입력받아 저장



#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct card
{
    int num;
    char name[50];
    char phone[50];
    char email[50];
} Card;
// 메인함수

Card input_business_card(Card* list);
void show_all_cards(Card* list);
void search_business_card(Card* list, int number);
void edit_business_card(Card* list);

int main(void) 
{
    int a;
    int number;

    Card list[50] = { NULL };


    while (1)
    {
        printf("1번 입력, 2번 수정, 3번 삭제, 4번 전체출력, 5번 검색, 6번 종료 : ");
        scanf("%d", &a);

        switch (a)
        {
        case 1:
            list[list->num] = input_business_card(list);
            break;
        case 2:
            edit_business_card(list);
            break;
        case 3:
            break;
        case 4:
            show_all_cards(list);
            break;
        case 5:
            printf("찾을 명함번호를 입력하세요 : ");
            scanf("%d", &number);
            search_business_card(list, number);
            break;
        case 6:
            break;
        default:
            break;
        }
    }


	system("pause");
	return EXIT_SUCCESS;
}

Card input_business_card(Card* list)
{
    printf("한글 이름을 입력하세요 : ");
    scanf("%s", &(list->name));
    printf("폰번호를 입력하세요 : ");
    scanf("%s", &(list->phone));
    printf("이메일을 입력하세요 : ");
    scanf("%s", &(list->email));
    (list->num)++;

    return* list;
}

void show_all_cards(Card* list)
{
    for (int i = 1; i <= list->num; i++)
    {
        printf("%d번 카드 %10d%10s%10s%10s\n", list[i].num, list[i].num, list[i].name, list[i].phone, list[i].email);
    }
}

void search_business_card(Card* list, int number)
{
    printf("%d번 카드 %10d%10s%10s%10s\n", list[number].num, list[number].num, list[number].name, list[number].phone, list[number].email);
}

void edit_business_card(Card* list)
{
    int find;
    printf("찾을 번호를 입력하세요 : ");
    scanf("%d", &find);

    printf("한글 이름을 입력하세요 : ");
    scanf("%s", &(list[find].name));
    printf("폰번호를 입력하세요 : ");
    scanf("%s", &(list[find].phone));
    printf("이메일을 입력하세요 : ");
    scanf("%s", &(list[find].email));

    return list;
}