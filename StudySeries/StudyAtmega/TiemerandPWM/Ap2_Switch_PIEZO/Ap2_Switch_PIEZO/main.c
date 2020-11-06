/*
 * Ap2_Switch_PIEZO.c
 *
 * Created: 2020-06-17 오후 1:50:44
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>

unsigned int DoReMi[8] = {261, 293, 329, 349, 391, 440, 493, 523};
volatile unsigned char sound_flag = 1;

int main(void)
{
	DDRE = 0x08;
	DDRD = 0x00;
	
	TCCR3A = 0x00;
	TCCR3B = 0x19;
	TCCR3C = 0x00;
	TCNT3 = 0x0000;

	EICRA = 0xff;
	EICRB = 0xff;

	EIMSK = 0xff;
	EIFR = 0xff;

	sei();

    while (1) 
    {
		if (sound_flag)
		{
			_delay_ms(2000);
			sound_flag = 0;
			TCCR3A = 0x00;
		}
    }

	return 0;
}

SIGNAL(INT0_vect){
	cli();
	ICR3 = (7372800/DoReMi[0])/10;
	
	sound_flag = 1;
	sei();
}
SIGNAL(INT1_vect){
	cli();
	ICR3 = (7372800/DoReMi[1])/10;
	TCCR3A = 0x40;
	sound_flag = 1;
	sei();
}
SIGNAL(INT2_vect){
	cli();
	ICR3 = (7372800/DoReMi[2])/10;
	TCCR3A = 0x40;
	sound_flag = 1;
	sei();
}
SIGNAL(INT3_vect){
	cli();
	ICR3 = (7372800/DoReMi[3])/10;
	TCCR3A = 0x40;
	sound_flag = 1;
	sei();
}
SIGNAL(INT4_vect){
	cli();
	ICR3 = (7372800/DoReMi[4])/10;
	TCCR3A = 0x40;
	sound_flag = 1;
	sei();
}
SIGNAL(INT5_vect){
	cli();
	ICR3 = (7372800/DoReMi[5])/10;
	TCCR3A = 0x40;
	sound_flag = 1;
	sei();
}
SIGNAL(INT6_vect){
	cli();
	ICR3 = (7372800/DoReMi[6])/10;
	TCCR3A = 0x40;
	sound_flag = 1;
	sei();
}
SIGNAL(INT7_vect){
	cli();
	ICR3 = (7372800/DoReMi[7])/10;
	TCCR3A = 0x40;
	sound_flag = 1;
	sei();
}