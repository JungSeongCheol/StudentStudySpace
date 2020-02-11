#pragma once

#define PI 3.141592
#define LIMIT 100.0
#define MSG "passed!"
#define ERR_PRN printf("허용 범위를 벗어났습니다.\n")
#define SUM(a, b) (a + b)
#define MUL(a, b) (a * b)
#define PRINT_EXP(x) printf(#x " = %d\n", x);
#define NAME_CAT(x, y) (x ## y)
#define VER 7
#define BIT 16

struct student
{
	int num;
	char name[20];
};

typedef struct student Student;