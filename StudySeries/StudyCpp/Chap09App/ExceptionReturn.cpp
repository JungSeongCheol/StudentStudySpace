#include <stdio.h>

enum E_Error { OUTOFMEMORY, OVERRANGE, HARDFULL, STACKFULL};

class Exception {
private:
	int ErrorCode;
public:
	Exception(int ae) : ErrorCode(ae) { ; }
	int GetErrorCode() { return ErrorCode; }
	void ReportError() {
		switch (ErrorCode)
		{
		case 1:
			puts("[ERROR] �޸𸮰� �����մϴ�.");
			break;
		case 2:puts("[ERROR] ���� ������ �ʰ��߽��ϴ�.");
			break;
		case 3:
			puts("[ERROR] �ϵ� ��ũ�� ���� á���ϴ�.");
			break;
		default:
			break;
		}
	}
};

void report() {
	if (true) throw Exception(2);

	// ������� ������ ������ �۾� �Ϸ�����.
}

int main() {
	try
	{
		report();
		puts("�۾��Ϸ�");
	}
	catch(Exception &e) {
		printf("���� �ڵ� = %d => ", e.GetErrorCode());
		e.ReportError();
	}

	return 0;

	//catch (E_Error e)
	//{
	//	switch (e)
	//	{
	//	case OUTOFMEMORY:
	//		puts("[ERROR] �޸� ����");
	//		break;
	//	case OVERRANGE:
	//		puts("[ERROR] ���� ���� �ʰ�");
	//		break;
	//	case HARDFULL:
	//		puts("[ERROR] �ϵ� ��ũ ����");
	//		break;
	//	case STACKFULL:
	//		puts("[ERROR] ���� �� ��");
	//		break;
	//	default:
	//		break;
	//	}
	//}
	//return 0;
}