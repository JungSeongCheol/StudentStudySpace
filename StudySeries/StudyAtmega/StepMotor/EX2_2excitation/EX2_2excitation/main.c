/*
 * EX2_2excitation.c
 *
 * Created: 2020-06-18 오전 9:42:03
 * Author : JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>

int main(void)
{
	unsigned char i;

	//DDRB = 0x80; //MOTOR1_ENABLE 
	DDRD = 0xf0;
	//PORTB &= 0x80; // M1 Disable, DC모터 정지

    /* Replace with your application code */
    while (1) 
    {
		for(i=0; i<12 ; i++)
		{
			PORTD = 0x30; //00110000
			_delay_ms(10);
			PORTD = 0x90; //1001
			_delay_ms(10);
			PORTD = 0xC0; //1100
			_delay_ms(10);
			PORTD = 0x60; //0110;
			_delay_ms(10);
		}
		_delay_ms(1000);
    }
}

