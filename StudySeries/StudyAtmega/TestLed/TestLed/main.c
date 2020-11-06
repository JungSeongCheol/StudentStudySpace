/*
 * TestLed.c
 *
 * Created: 2020-06-12 오후 3:09:38
 * Author : JSC
 */ 

#include <avr/io.h>


int main(void)
{
	DDRA = 0xFF;
	DDRB = 0xFF;
	DDRC = 0xFF;
	DDRD = 0XFF;
	DDRE = 0xFF;
	DDRF = 0XFF;
	DDRG = 0b000111111;
    /* Replace with your application code */
    while (1) 
    {
		PORTA = 0xFF;
		PORTB = 0xFF;
		PORTC = 0xFF;
		PORTD = 0xFF;
		PORTE = 0xFF;
		PORTF = 0xFF;
		PORTG = 0b000111111;
    }
}

