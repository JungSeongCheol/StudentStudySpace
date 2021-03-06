#include <string>
#include <iostream>
using namespace std;

int main() {
	string s1("안녕하세요~");
	string s2;

	s2 = "씨뿔뿔";
	cout << s2 << endl;
	s2 = s1;
	cout << s1 << endl;

	s1 += "세계여!!";
	cout << s1 << endl;
	
	string s3;
	s3 = "s1: " + s1 + " s2 : " + s2;
	cout << s3 << endl;

	string s4("1234567890");
	string s5("abcdefghijklmnop");
	string s6;

	s6.assign(s4, 3, 4);
	cout << s6 << endl;
	s6.append(s5, 3, 2);
	cout << s6 << endl;

	string s7("^_^");
	cout << s4.insert(5, "XXX") << endl;
	cout << s4.insert(8, s7) << endl;
	cout << s4.erase(5, 6) << endl;

	string s8 = "독도는 일본땅";

	cout << s8 << endl;
	s8.replace(7, 4, "대한민국");
	cout << s8 << endl;

	string s9("1234567890");
	string s10 = s9.substr(3, 4);
	
	cout << s10 << endl;

	string s11("aab");
	string s12("aaa");

	cout << (s11 == s11 ? "같다" : "다르다") << endl;
	cout << (s11 == s12 ? "같다" : "다르다") << endl;
	cout << (s11 > s12 ? "크다" : "같거나 다르다") << endl; //문자열 정리시에도 aab > aaa로 비교해서 정렬한다.

	string s13("1234567");
	string s14("1234999");

	cout << (s13.compare(s14) == 0 ? "같다" : "다르다") << endl;
	cout << (s13.compare(0, 4, s14, 0, 4) == 0 ? "같다" : "다르다") << endl;

	string s15("hongkildong");
	cout << (s15 == "hongkildong" ? "같다" : "다르다") << endl;

	string s16("string class find function.");
	string s17("func");

	cout << endl;
	cout << s16.find('i') << "번째" << endl;
	cout << s16.find('i', 10) << "번째" << endl;
	cout << s16.find(s17) << "번쨰" << endl;

	string s18("StarCraft");
	cout << s18.find('t') << "번째" << endl;
	cout << s18.rfind('t') << "번째"<< endl;
	cout << s18.find_first_of("aeiou") << "번째" << endl;
	cout << s18.find_last_of("aeiou") << "번쨰" <<endl;
	cout << s18.find_first_not_of("aeiou") << "번째" << endl;

	return 0;
}