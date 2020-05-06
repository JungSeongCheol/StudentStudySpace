#include <stdio.h>
#include <conio.h>
#include <string.h>

int main() {
	int num, age;
	char name[12];
	int height;

	try
	{
		printf("학번을 입력하세요 : ");
		scanf("%d", &num);
		if (num <= 0) throw num;

		try
		{
			printf("이름을 입력하세요 : ");
			scanf("%s", &name);
			if (strlen(name) < 4) throw "[Err] 이름이 너무 짧음"; // 한글 한자리는 2byte, 따라서 2자리 부터는 가능(한글은), 문자열의 길이에서 한글의 특징임.
			printf("나이를 입력하세요 : ");
			scanf("%d", &age);
			if (age <= 0) throw age;

			try
			{
				printf("키를 입력하세요 : ");
				scanf("%d", &height);
				if (height <= 0) throw height;
			}
			catch (int height)
			{
				printf("[ERROR] 키는 0보다 작을 수 없다.\n");
			}

			printf("입력한 정보, 학번 %d, 이름 %s, 나이 %d, 키 %d\n", num, name, age, height);

		}
		catch (const char* message)
		{
			puts(message);
		}
		catch (int)
		{
			throw; //밖에있는 try로 던짐, 그후 밖에있는 catch로 가서 처리가 됨.
		}
	}
	catch (int n)
	{
		printf("[Err] %d 자연수가 아니므로 실행되지 않음", n);
	}
}