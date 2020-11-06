/*
 * Ex4_SWITCH.c
 *
 * Created: 2020-06-15 오전 10:08:13
 * Author : JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>

int main(){
	DDRB = 0x04;
	PORTB = 0x04;
	return 0;
}

