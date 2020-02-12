/*
  filename - main.c
  version - 1.0
  description - 기본 메인 함수, MySQL 연결 테스트
  --------------------------------------------------------------------------------
  first created - 2020.02.12
  writer - Hugo MG Sung.
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <my_global.h>
#include <winsock.h>
#include <mysql.h>

#pragma comment(lib, "libmysql.lib")

#define MYSQLUSER "root"
#define MYSQLPASSWORD "mysql_p@ssw0rd"
#define MYSQLIP "localhost"
#define USEMYSQLDB "use shopdb;"

void loadmysql(char mysqlip[], MYSQL* cons); // 함수선언 필요

// 메인함수
int main(void)
{
    MYSQL* cons = mysql_init(NULL);
    MYSQL_RES* res;
    MYSQL_ROW row;
    int fields;

    loadmysql(MYSQLIP, cons);   //함수 호출
    printf("\n");
    mysql_query(cons, USEMYSQLDB);
    mysql_query(cons, "SELECT * FROM membertbl;");
    res = mysql_store_result(cons);
    fields = mysql_num_fields(res);

    while (row = mysql_fetch_row(res))
    {
        for (int i = 0; i < fields; i++)
        {
            printf("%s", row[i]);
            if (i < fields)
            {
                printf("\t");
            }
        }
        printf("\n");
    }

    mysql_free_result(res);
    mysql_close(cons);

	system("pause");
	return EXIT_SUCCESS;
}

void loadmysql(char mysqlip[], MYSQL* cons) //함수 정의
{
    if (cons == NULL)
    {
        fprintf(stderr, "%s\n", mysql_error(cons));
        sleep(1000);    //ms를 기준(컴퓨터는 기본적으로 ms를 씀
        exit(EXIT_FAILURE);
    }

    if ((mysql_real_connect(cons, mysqlip, MYSQLUSER, MYSQLPASSWORD, NULL, 0, NULL, 0) != NULL))
    {
        fprintf(stdout, "접속성공\n");
        mysql_set_character_set(cons, "euckr");
    }

    else
    {
        fprintf(stderr, "연결오류 :%s\n", mysql_error(cons));
        getchar();
    }
}