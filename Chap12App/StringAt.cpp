#include <string>
#include <iostream>
using namespace std;

int main() {
	string str("Korea");
	size_t len;
	
	len = str.size();
	cout << "문자열 길이 : " << len << endl;

	for (int i = 0; i < len; i++)
	{
		cout << str[i];
	}
	cout << endl;

	str[0] = 'C'; // 한글로 하면 깨짐

	for (int i = 0; i < len; i++)
	{
		cout << str.at(i);
	}
	cout << endl;

	return 0;
}