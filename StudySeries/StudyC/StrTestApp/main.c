/*
  filename - main.c
  version - 1.0
  description - �⺻ ���� �Լ�, ���ڿ� �н�
  --------------------------------------------------------------------------------
  first created - 2020.02.05
  writer - Jung Seong Cheol
*/

#include <stdio.h>
#include <stdlib.h>

// �����Լ�
int main(void) 
{
    //char *dessert = "apple";

    //printf("������ �Ľ��� %s�Դϴ�.\n", dessert);
    //dessert = "banana";
    //printf("������ �Ľ��� %s�Դϴ�.\n", dessert);
	
    //char str[80];

    //printf("������ ���Ե� ���ڿ� �Է� : ");
    //fgets(str, sizeof(str), stdin);
    //// ���߿� �Է��� �����Դϴ�.
    //printf("�Էµ� ���ڿ��� %s�Դϴ�. \n", str);

    //int age;
    //char name[20];

    //printf("���� �Է� : ");
    //scanf("%d", &age);
    //getchar();
    //printf("�̸� �Է� : ");
    //gets(name);
    //printf("����: %d, �̸� : %s\n", age, name);

    //   char str[80] = "apple juice";
    //   char* ps = "banana";

    //   puts(str);
    //   fputs(ps, stdout);
    //   puts("milk");

    //char str1[80] = "strawberry";
    //char str2[80] = "apple";
    //char* ps1 = "banana";
    //char* ps2 = str2;

    //printf("���� ���ڿ� : %s\n", str1);
    //strcpy(str1, str2);
    //printf("�ٲ� ���ڿ� : %s\n", str1);

    //strcpy(str1, ps1);
    //printf("�ٲ� ���ڿ� : %s\n", str1);

    //strcpy(str1, ps2);
    //printf("�ٲ� ���ڿ� : %s\n", str1);

    //strcpy(str1, "raspberry");
    //printf("�ٲ� ���ڿ� : %s\n", str1);

    //char str[20] = "mango tree";
    //strncpy(str, "apple", 5);
    //printf("��ȯ ��Ʈ�� %s\n", str);

    //char str[80] = "straw";

    //strcat(str, "berry");
    //printf("%s\n", str);
    //strncat(str, "piece", 3);
    //printf("%s\n", str);

    //char str1[80], str2[80];
    //char* resp;

    //printf("2���� ���� �̸� �Է� : ");
    //scanf("%s%s", str1, str2);
    //if (strlen(str1) > strlen(str2))
    //    resp = str1;
    //else
    //    resp = str2;
    //printf("�̸��� �� ������ : %s\n", resp);

    char str1[80] = "pear";
    char str2[80] = "peach";

    printf("������ ���߿� ������ ���� �̸� : ");
    if (strcmp(str1, str2) > 0)
        printf("%s\n", str1);
    else
        printf("%s\n", str2);

    system("pause");
    return EXIT_SUCCESS;
}