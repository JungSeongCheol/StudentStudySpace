#include <stdio.h>

#define MYSQLUSER "root"					//�����̸�
#define MYSQLPASSWORD "mysql_p@ssw0rd"		//�н����� ��ȣ

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
	//���⼭ DB������ ����
	hCon = 1234;
	puts("����Ǿ����ϴ�.");
}

void DBQuery::DBDisConnect()
{
	//������ �����Ѵ�.
	hCon = NULL;
	puts("������ ���������ϴ�.");
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
	DBQuery Q1, Q2, Q3; //�ʿ��� DB���� ����.

	//�ʿ��� DB ���Ǹ� �Ѵ�.
	Q1.RunQuery("select * from tblBuja where ���� ģ�ѻ��");

	DBQuery::DBDisConnect();
}