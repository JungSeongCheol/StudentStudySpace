#include <iostream>
#include <fstream>
using namespace std;

int main() {
	ofstream f;

	f.open("C:\\Temp\\test.txt");
	if (f.is_open()){
		f << "String" << 1234 << endl;
		f.close();
	}
	else {
		cerr << "���� ���� ����" << endl;
	}

	ifstream fi;
	char str[128];
	int i = 0;

	fi.open("C:\\Temp\\test.txt");

	if (fi.is_open()){
		fi.getline(str, 128);
		cout << str << i << endl;
		fi.close();
	}
	else {
		cerr << "���� ���� ���� " << endl;
	}

	return 0;
}