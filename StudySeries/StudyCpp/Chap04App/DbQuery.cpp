#include <stdio.h>

#define MYSQLUSER "root"					//유저이름
#define MYSQLPASSWORD "mysql_p@ssw0rd"		//패스워드 번호

class DBQuery
{
private:
	static int hCon;
	int nResult;

public:
	DBQuery() {};
	static void DBConnect(const char* Sever, const char* ID, const char* Pass);
	static void DBDisConnect();
	bool RunQuery(const char* SQL);
	// blar blar blar

};

int DBQuery::hCon;

void DBQuery::DBConnect(const char* Server, const char* ID, const char* Pass)
{
	//여기서 DB서버에 접속
	hCon = 1234;
	puts("연결되었습니다.");
}

void DBQuery::DBDisConnect()
{
	//접속을 해제한다.
	hCon = NULL;
	puts("연결이 끊어졌습니다.");
}

bool DBQuery::RunQuery(const char* SQL)
{
	//Query(hCon,SQL);
	puts(SQL);
	return true;
}

int main()
{
	//DBQuery* dbcon = newDBQuery();
	//DBQuery dbcon(2);

	DBQuery::DBConnect("Secret", "Adult", "doemfdmsrkfk");
	DBQuery Q1, Q2, Q3; //필요한 DB쿼리 실행.

	//필요한 DB 질의를 한다.
	Q1.RunQuery("select * from tblBuja where 나랑 친한사람");

	DBQuery::DBDisConnect();
}