#include <stdio.h>
#include "cursor.h"

class RandNum
{
private:
	int num;

public:
	RandNum() { randomize(); }
	void Generate() { num = random(100) + 1; }
	BOOL Compare(int input) {
		if (input == num) {
			printf("맞췄습니다.\n");
			return TRUE;
		}
		else if (input > num) {
			printf("입력한 숫자보다 더 작습니다.\n");
		}
		else {
			printf("입력한 숫자보다 더 큽니다.\n");
		}
		return FALSE;
	}
};

class Ask
{
private:
	int input;

public:
	void Prompt() { printf("\n제가 만든 숫자를 맞춰 보세요.\n"); }
	BOOL AskNumber() {
		printf("숫자를 입력하세요(끝낼 때는 999) : ");
		scanf("%d", &input);
		if (input == 999) {
			return TRUE;
		}
		return FALSE;
	}
	int GetInput() { return input; }
};

int main()
{
	RandNum R;
	Ask A;

	while (1) {
		R.Generate();	//정의로 이동할때는 f12, 다시 갈때는 ctrl + -
		A.Prompt();
		for (;;) {
			if (A.AskNumber()) {
				exit(EXIT_SUCCESS);
			}
			if (R.Compare(A.GetInput())) {
				break;
			}
		}
	}
}

