#include <stdio.h>
#include <stdlib.h>
#include <arpa/inet.h>
void error_handling(char *message);

int main(int argc, char *argv[]){
	char *addr="127.232.124.79";
	struct sockaddr_in addr_inet; //struct sockaddr_in이란 구조체를 addr_inet으로 변수 선언

	if(!inet_aton(addr, &addr_inet.sin_addr)) //addr_inet안의 sin_addr을 참조. and sin_addr에 addr을 집어 넣는다.
		error_handling("Conversion error");
	else
		printf("Network ordered integer addr: %#x \n", addr_inet.sin_addr.s_addr);
	return 0;
}

void error_handling(char *message){
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}
