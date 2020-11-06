#include <stdio.h>

namespace UTIL {
	int value;
	double score;
	void sub() { puts("sub routine"); }
}

namespace VeryVeryLongLongNameSapceNameInTheWorld {
	// --
	int value;
}

namespace MyCompany {
	namespace Research {
		namespace GameEngine {
			//...
		}
	}
}

int value;

int main() {
	namespace MRG = MyCompany::Research::GameEngine;
	namespace A = VeryVeryLongLongNameSapceNameInTheWorld;
	using UTIL::value;
	value = 5;
	UTIL::score = 1.234;
	UTIL::sub();

	return 0;
}

void mysub() {
	UTIL::value = 5;
}