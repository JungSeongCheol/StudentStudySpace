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
			puts("[ERROR] 메모리가 부족합니다.");
			break;
		case 2:puts("[ERROR] 연산 범위를 초과했습니다.");
			break;
		case 3:
			puts("[ERROR] 하드 디스크가 가득 찼습니다.");
			break;
		default:
			break;
		}
	}
};

void report() {
	if (true) throw Exception(2);

	// 여기까지 왔으면 무사히 작업 완료했음.
}

int main() {
	try
	{
		report();
		puts("작업완료");
	}
	catch(Exception &e) {
		printf("에러 코드 = %d => ", e.GetErrorCode());
		e.ReportError();
	}

	return 0;

	//catch (E_Error e)
	//{
	//	switch (e)
	//	{
	//	case OUTOFMEMORY:
	//		puts("[ERROR] 메모리 부족");
	//		break;
	//	case OVERRANGE:
	//		puts("[ERROR] 연산 범위 초과");
	//		break;
	//	case HARDFULL:
	//		puts("[ERROR] 하드 디스크 꽉참");
	//		break;
	//	case STACKFULL:
	//		puts("[ERROR] 스택 꽉 참");
	//		break;
	//	default:
	//		break;
	//	}
	//}
	//return 0;
}