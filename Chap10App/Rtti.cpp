//#include <stdio.h>
//
//class Parent
//{
//public:
//	virtual void PrintMe() { printf("I am Parent\n"); }
//};
//
//class Child : public Parent
//{
//private:
//	int num;
//
//public:
//	Child(int anum) : num(anum) { }
//	virtual void PrintMe() { printf("I am Child\n"); }
//	void PrintNum() { printf("Hello Child = %d\n", num); }
//};
//
//void func(Parent* p)
//{
//	p->PrintMe();
//	((Child*)p)->PrintNum();
//}
//
//int main()
//{
//	Parent p;
//	Child c(5);
//	printf("size of p %d, size of c %d\n", sizeof(p), sizeof(c)); //포인터 기본 size 4 (p = 4), int또한 가지고있는 c는 8 4+4(c = 8)
//
//	func(&c);
//	func(&p); // parent 는 num의 숫자가 없으므로 쓰레기 값이 나옴.
//}
#include <stdio.h>
#include <typeinfo>

class Parent
{
public:
	virtual void PrintMe() { printf("I am Parent\n"); }
};

class Child : public Parent
{
private:
	int num;

public:
	Child(int anum) : num(anum) { }
	virtual void PrintMe() { printf("I am Child\n"); }
	void PrintNum() { printf("Hello Child = %d\n", num); }
};

void func(Parent* p)
{
	p->PrintMe();
	if (typeid(*p) == typeid(Child)) {
		((Child*)p)->PrintNum();
	}
	else { puts("이 객체는 num을 가지고 있지 않습니다."); }
	
}

int main()
{
	Parent p, *pP;
	Child c(5), *pC;
	pP = &p;
	pC = &c;

	printf("p=%s, pP=%s, *pP= %s\n", typeid(p).name(), typeid(pP).name(), typeid(*pP).name());
	printf("c=%s, pC=%s, *pC= %s\n", typeid(c).name(), typeid(pC).name(), typeid(*pC).name());
	func(pP);

	pP = &c;
	printf("p=%s, pP=%s, *pP= %s\n", typeid(c).name(), typeid(pP).name(), typeid(*pP).name());
	int a = 0;

	printf("%s, %s, %s\n", typeid(a).name(), typeid(double).name(), typeid(char).name());
	func(pP);
}
