/*
 * EX7_FNDLED.c
 *
 * Created: 2020-06-15 오전 11:02:46
 * Author : JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>

int Count_TR(unsigned char flag);

int main(){
	
	unsigned char FND_DATA_TBL [] = {0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7c, 0x07, 0x7f, 0x67, 0x77, 0x7c, 0x39, 0x5e, 0x79, 0x71, 0x88, 0x80};

	unsigned int cnt = 0;
	unsigned char Switch_flag = 0;

	DDRA = 0xff;
	DDRE = 0x00;

	while(1){

	}
}
