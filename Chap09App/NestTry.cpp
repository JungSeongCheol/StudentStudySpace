#include <stdio.h>
#include <conio.h>
#include <string.h>

int main() {
	int num, age;
	char name[12];
	int height;

	try
	{
		printf("�й��� �Է��ϼ��� : ");
		scanf("%d", &num);
		if (num <= 0) throw num;

		try
		{
			printf("�̸��� �Է��ϼ��� : ");
			scanf("%s", &name);
			if (strlen(name) < 4) throw "[Err] �̸��� �ʹ� ª��"; // �ѱ� ���ڸ��� 2byte, ���� 2�ڸ� ���ʹ� ����(�ѱ���), ���ڿ��� ���̿��� �ѱ��� Ư¡��.
			printf("���̸� �Է��ϼ��� : ");
			scanf("%d", &age);
			if (age <= 0) throw age;

			try
			{
				printf("Ű�� �Է��ϼ��� : ");
				scanf("%d", &height);
				if (height <= 0) throw height;
			}
			catch (int height)
			{
				printf("[ERROR] Ű�� 0���� ���� �� ����.\n");
			}

			printf("�Է��� ����, �й� %d, �̸� %s, ���� %d, Ű %d\n", num, name, age, height);

		}
		catch (const char* message)
		{
			puts(message);
		}
		catch (int)
		{
			throw; //�ۿ��ִ� try�� ����, ���� �ۿ��ִ� catch�� ���� ó���� ��.
		}
	}
	catch (int n)
	{
		printf("[Err] %d �ڿ����� �ƴϹǷ� ������� ����", n);
	}
}