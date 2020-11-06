#include <stdio.h>

class A {
protected:
	int a;
public:
	A(int aa) :a(aa) { ; }
};

class B : virtual public A {
protected:
	int b;
public:
	B(int aa, int bb) : A(aa), b(bb) { ; }
};

class C : virtual public A {
protected:
	int c;
public:
	C(int aa, int cc) : A(aa), c(cc) { ; }
};

class D : public B, public C {
protected:
	int d;
public:
	D(int aa, int ab, int ac, int ad) : A(aa), B(aa, ab), C(aa, ac) { 
		d = ad;
	}

	void fD() {
		b = 1;
		c = 2;
		a = 3; // 에러 (다이아몬드 에러) virtual을 적지않으면 에러가 난다.
		d = 4;
	}

	void Out() {
		printf("%d, %d, %d, %d\n", a, b, c, d);
	}
};

int main() {
	D d(2, 4, 6, 8);
	d.Out();
	d.fD();
	d.Out();

	return 0;
}