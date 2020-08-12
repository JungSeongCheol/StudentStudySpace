/*
 * EX7_InputFnd.c
 *
 * Created: 2020-06-15 오전 11:22:15
 * Author : JSC
 */ 


#include <avr/io.h>
#include <util/delay.h>

int Count_TR(unsigned char flag);

int main(){
								//     0	1		2	3		4	5	  6		7	  8		9	  A		B		c	d	  e		f	
	unsigned char FND_DATA_TBL [] = {0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7c, 0x07, 0x7f, 0x6f, 0x77, 0x7c, 0x39, 0x5e, 0x79, 0x71, 0x88, 0x80};

	int cnt = 0;
	unsigned char Switch_flag = 0;

	DDRA = 0xff;
	DDRD = 0x00;

	while(1){
		Switch_flag = PIND;
		while(PIND != 0x00);

		if(Switch_flag != 0)
			cnt += Count_TR(Switch_flag);

		if(cnt < 0){
			cnt = 0;
		}

		else if(cnt > 15){
			cnt = 15;
		}

		PORTA = FND_DATA_TBL[cnt];
		_delay_ms(200);
	}
}

int Count_TR(unsigned char flag){
	int count = 0;
	switch(flag){
		case 0x01:
			count = 1;
			break;
		case 0x02:
			count = 2;
			break;
		case 0x04:
			count = 3;
			break;
		case 0x08:
			count = 4;
			break;
		case 0x10:
			count = -1;
			break;
		case 0x20:
			count = -2;
			break;
		case 0x40:
			count = -3;
			break;
		case 0x80:
			count = -4;
			break;
	}
	return count;
}