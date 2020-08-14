#define RCC     0x40023800
#define RCC_AHB1ENR     *((unsigned int*)(RCC + 0x30))     //0x40023830
//다들 주소를 나타내므로 - 포인터로 써줘야된다.

#define GPIOC    0x40020800
#define GPIOC_MODER     *((unsigned int*)(GPIOC + 0x00))
#define GPIOC_OTYPER    *((unsigned int*)(GPIOC + 0x04))
#define GPIOC_OSPEEDR   *((unsigned int*)(GPIOC + 0x08))
#define GPIOC_PUPDR     *((unsigned int*)(GPIOC + 0x0c))
#define GPIOC_IDR       *((unsigned int*)(GPIOC + 0x10))
#define GPIOC_ODR       *((unsigned int*)(GPIOC + 0x14))

static void delay(const unsigned count){
  unsigned int i = 0;
  for(i = (8000 * count); i!=0; i--);
}
int main(){
  RCC_AHB1ENR = 0x00000004;     // PORT clock enable
  GPIOC_MODER = 0x00000055;     // PORT[3:0] OUTPUT
  GPIOC_OTYPER = 0x00000000;    // push-pull
  GPIOC_OSPEEDR = 0x00000000;   // SPEED
  GPIOC_PUPDR = 0x00000000;    // NO PULL-UP PULL-DOWN
  
  while(1){
    GPIOC_ODR = 0x0005; // 0, 2 ON 1, 3 OFF
    delay(1000);
    GPIOC_ODR = 0x000A; // 1, 3 ON 0, 2 OFF
    delay(1000);
  }
}