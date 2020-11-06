/*
 * AP1_UART_SWITCH.c
 *
 * Created: 2020-06-17 오후 3:46:03
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

volatile unsigned char Tx_flag = 0;
volatile char TX_data = 0;

void putch(unsigned char data){
	while((UCSR0A & 0x20) == 0);
	UDR0 = data;
	UCSR0A |= 0x20;
}

void putch_Str(char *str){
	unsigned char i = 0;
	while(str[i]!= '0')
	putch(str[i++]);
}

int main(void)
{
	DDRE = 0x02;
	UCSR0A = 0x00;
	UCSR0B = 0x18;
	UCSR0C = 0x06;
	UBRR0H = 0x00;
	UBRR0L = 0x03;
	
	EICRB = 0xff;
	EIMSK = 0xf0;
	EIFR = 0xf0;
	sei();
	 
    while (1) 
    {
		if(Tx_flag == 1){
			putch_Str("\n\r Input Switch : ");
			putch(TX_data);
			Tx_flag = 0;
		}
    }
}

SIGNAL(INT4_vect){
	cli();
	TX_data = '0';
	Tx_flag = 1;
	sei();
}

SIGNAL(INT5_vect){
	cli();
	TX_data = '1';
	Tx_flag = 1;
	sei();
}

SIGNAL(INT6_vect){
	cli();
	TX_data = '2';
	Tx_flag = 1;
	sei();
}

SIGNAL(INT7_vect){
	cli();
	TX_data = '3';
	Tx_flag = 1;
	sei();
}
