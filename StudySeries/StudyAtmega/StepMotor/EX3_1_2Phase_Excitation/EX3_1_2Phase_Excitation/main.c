/*
 * EX3_1_2Phase_Excitation.c
 *
 * Created: 2020-06-18 오전 10:05:10
 * Author : JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>

unsigned char Step[8] = {0x90, 0x80, 0xC0, 0x40, 0x60, 0x20, 0x30, 0x10};

int main(void)
{
	unsigned char i, t = 0;

	//DDRB = 0x20;
	DDRD = 0xf0;
	//PORTB &= ~0x20;
    /* Replace with your application code */
    
	while (1) 
    {
		for(i=0; i<24; i++)
		{
			PORTD = Step[t];
			t++;
			if(t > 7) t=0;
			_delay_ms(10);
		}
		_delay_ms(1000);
    }
}

