#include <list>
#include <typeinfo>
#include <iostream>

using namespace std;

struct MCommand {
	int key;
	int value;
};

typedef list<MCommand*> LIST_COMMAND;

auto func() { return 3.141592; };

int main() {
	// const char*
	const char* NPCName = "Farmer";
	cout << NPCName << endl;

	//int
	auto Number = 3.141592;
	cout << Number << endl;

	//int*
	int UserMode = 4;
	auto pUserMode = &UserMode;
	cout << "pUserMode = " << *pUserMode << " : Address = " << pUserMode << endl;

	auto& refUserMode = UserMode;

	LIST_COMMAND m_listcommand;
	// LIST_COMMAND::iterator iter = m_listcommand.begin();

	auto iter = m_listcommand.begin();

	auto result = func();
	cout << "result is " << result << endl;
	cout << typeid(result).name() << endl;

	return 0;
}