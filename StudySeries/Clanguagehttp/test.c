#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char webpage[] = "HTTP/1.1 200 OK\r\n",
    "Server:Linux WebServer\r\n",
    "Content-Type:text/html; charset=UTF-8\r\n\r\n",
    "<!DOCTYPE Html>\r\n",
    "<html><head><title> MY Web Page </title>\r\n",
    "<stylebody {background-color: #FFFF00}</style></head>\r\n",
    "<body><center><h1>Hello World!!<h1><\br>\r\n",
    "<img src=\"cat.jpg\"></center></body><html>\r\n";


int main(int argc, char* argv[])

