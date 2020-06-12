#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <arpa/inet.h>
#include <sys/socket.h>
#include <pthread.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <sys/types.h>

#define BUF_SIZE 50000

char webpage[] = "HTTP/1.1 200 OK\r\n"
  	"Server:Linux WebServer\r\n"
  	"Content-Type:text/html; charset=UTF-8\r\n\r\n"
  	"<!DOCTYPE Html>\r\n"
  	"<html><head><title> MY Web Page </title>\r\n"
  	"<style>body {background-color: #FFFF00}</style></head>\r\n"
  	"<body><center><h1>Hello World!!<h1><br>\r\n"
  	"<img src=\"./cat.jpg\"></center></body></html>\r\n";

void error_handling(char* message);

void* webPrint(void* arg);

int main(int argc, char *argv[]){
	int serv_sock, clnt_sock;
	struct sockaddr_in serv_adr;
	struct sockaddr_in clnt_adr;
	
	int clnt_adr_size;
	char buf[BUF_SIZE];
	pthread_t t_id;
	if(argc!=2){
		printf("Usage : %s <port>\n", argv[0]);
		exit(1);
	}

	serv_sock=socket(PF_INET, SOCK_STREAM, 0);
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family=AF_INET;
	serv_adr.sin_addr.s_addr=htonl(INADDR_ANY);
	serv_adr.sin_port = htons(atoi(argv[1]));
	
	if(bind(serv_sock, (struct sockaddr*)&serv_adr, sizeof(serv_adr))==-1)
		error_handling("bind() error!");

	if(listen(serv_sock, 20)==-1)
		error_handling("listen() error!");
	
	while(1){
		clnt_adr_size=sizeof(clnt_adr);
		clnt_sock=accept(serv_sock, (struct sockaddr*)&clnt_adr, &clnt_adr_size);
		if(clnt_sock == -1)
			error_handling("accept() error!");
			
		printf("Connection Request : %s:%d\n", inet_ntoa(clnt_adr.sin_addr), ntohs(clnt_adr.sin_port));
		pthread_create(&t_id, NULL, webPrint, &clnt_sock);
		pthread_detach(t_id);
		
	}
	close(serv_sock);
	return 0;
}

void *webPrint(void *arg){
	int clnt_sock=*((int*)arg);
	int clnt_sock1=*((int*)arg);
	int imga;
	
	char buf[BUF_SIZE];
	char bimg[BUF_SIZE];
	FILE* clnt_read;
	FILE* clnt_write;
	
	clnt_read = fdopen(clnt_sock, "r");
	clnt_write = fdopen(dup(clnt_sock), "w");
	
	memset(buf, 0, BUF_SIZE);
	read(clnt_sock1, buf, BUF_SIZE);
	if(strncmp(buf, "GET / HTTP", 10)){
		imga = open("./cat.jpg", O_RDONLY);
		read(imga, bimg, sizeof(bimg));
		write(clnt_sock1,bimg,sizeof(bimg));
		close(imga);
	}
	fprintf(clnt_write, "%s", webpage);
	fflush(clnt_write);
	fclose(clnt_write);
	close(clnt_sock);
	close(clnt_sock1);
}

void error_handling(char* message){
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}
