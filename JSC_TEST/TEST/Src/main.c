/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * <h2><center>&copy; Copyright (c) 2020 STMicroelectronics.
  * All rights reserved.</center></h2>
  *
  * This software component is licensed by ST under BSD 3-Clause license,
  * the "License"; You may not use this file except in compliance with the
  * License. You may obtain a copy of the License at:
  *                        opensource.org/licenses/BSD-3-Clause
  *
  ******************************************************************************
  */
/* USER CODE END Header */

/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "adc.h"
#include "dma.h"
#include "i2c.h"
#include "tim.h"
#include "usart.h"
#include "gpio.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "lcd.h"
#include "string.h"
#include "stdio.h"

/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
#define SHT2x_ADDR              0x40<<1 //(0b10000000)
#define SHT2x_HOLD_MASTER_T     0xE3
#define SHT2x_HOLD_MASTER_RH    0xE5
#define SHT2x_NOHOLD_MASTER_T   0xF3
#define SHT2x_NOHOLD_MASTER_RH  0xF5
#define SHT2x_WRITE_USER_REG    0XE6
#define SHT2x_READ_USER_REG     0xE7
#define SHT2x_SOFT_RESET        0xFE
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/

/* USER CODE BEGIN PV */
uint8_t i2cData[2];
uint16_t val = 0;
uint8_t mode;
float TEMP, HUMI;      //온도 습도
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
/* USER CODE BEGIN PFP */
void LED();
void Cds();
void Sound(unsigned char a);
void SHTemp();
/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */
uint8_t rxData;
uint8_t Input;
uint16_t CCR1_val = 0;
uint16_t adcData = 0;
char str[10];
unsigned int DoReMi[8] = {523, 587, 659, 698, 783, 880, 987, 1046};
unsigned long pwmfreq;
unsigned char piano = 0;
unsigned char STOP = 0;
/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_DMA_Init();
  MX_USART1_UART_Init();
  MX_ADC1_Init();
  MX_I2C1_Init();
  MX_TIM2_Init();
  /* USER CODE BEGIN 2 */
  HAL_UART_Receive_IT(&huart1, &rxData, 1);
  
  unsigned char text[] = "  ++++ Menu ++++\n L. LED - PWM\n C. CDS - ADC(DMA) LCD 출력\n";
  unsigned char text1[] = " 0 ~ 7. Digital Piano - PWM\n T. 온/습도센서 - I2C LCD 출력\n  push S/W = STOP(Interrupt)\n";
  unsigned char i=0;
  lcdInit();
  while(text[i]!='\0'){
    HAL_UART_Transmit(&huart1, &text[i], sizeof(text[i]), 10);
    i++;
  }
  i = 0;
  while(text1[i]!='\0'){
    HAL_UART_Transmit(&huart1, &text1[i], sizeof(text1[i]), 10);
    i++;
  }
  
  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    Input = rxData;
    
    switch(Input){
      case 'L':
        rxData = 0;
        LED();
        break;
      case 'C':
        rxData = 0;
        Cds();
        break;
      case '0':
        rxData = 0;
        piano = 0;
        Sound(piano);
        break;
      case '1':
        rxData = 0;
        piano = 1;
        Sound(piano);
        break;
      case '2':
        rxData = 0;
        piano = 2;
        Sound(piano);
        break;
      case '3':
        rxData = 0;
        piano = 3;
        Sound(piano);
        break;
      case '4':
        rxData = 0;
        piano = 4;
        Sound(piano);
        break;
      case '5':
        rxData = 0;
        piano = 5;
        Sound(piano);
        break;
      case '6':
        rxData = 0;
        piano = 6;
        Sound(piano);
        break;
      case '7':
        rxData = 0;
        piano = 7;
        Sound(piano);
        break;
      case 'T':
        rxData = 0;
        SHTemp();
        break;
    }
    
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Configure the main internal regulator output voltage 
  */
  __HAL_RCC_PWR_CLK_ENABLE();
  __HAL_PWR_VOLTAGESCALING_CONFIG(PWR_REGULATOR_VOLTAGE_SCALE1);
  /** Initializes the CPU, AHB and APB busses clocks 
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLM = 4;
  RCC_OscInitStruct.PLL.PLLN = 168;
  RCC_OscInitStruct.PLL.PLLP = RCC_PLLP_DIV2;
  RCC_OscInitStruct.PLL.PLLQ = 4;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }
  /** Initializes the CPU, AHB and APB busses clocks 
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV4;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV2;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_5) != HAL_OK)
  {
    Error_Handler();
  }
}

/* USER CODE BEGIN 4 */
void LED(){
  HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_1);
  while (1)
  {
    TIM2->CCR1 = CCR1_val;
    CCR1_val++;
    if(CCR1_val > 100) CCR1_val = 0;
    HAL_Delay(10);
    if(STOP == 1){
      CCR1_val = 0;
      TIM2->CCR1 = CCR1_val;
      STOP = 0;
      break;
    }
  }
}

void Cds(){
  while (1)
  {
    HAL_ADC_Start_DMA(&hadc1, (uint32_t*)&adcData, sizeof(adcData));
    lcdClear();
    lcdGotoXY(0,0);
    lcdPrintData("ADC DMA", 7);
    adcData = HAL_ADC_GetValue(&hadc1);
    sprintf(str, "ADC : %d", adcData);
    lcdGotoXY(0, 1);
    lcdPrint(str);
    HAL_Delay(500);
     if(STOP == 1){
      lcdClear();
      STOP = 0;
      break;
    }
  }
}

void Sound(unsigned char a){
  MX_TIM2_Init();
  HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_2);
  pwmfreq = (84000000/DoReMi[a]);
  TIM2->PSC = 0;
  TIM2->ARR = pwmfreq -1;
  TIM2->CCR2 = pwmfreq/10;
  //TIM2->EGR = TIM2->EGR & 0xfe;
  HAL_Delay(1000);
  MX_TIM2_Init();
}

void SHTemp(){
  while (1){
    mode = SHT2x_NOHOLD_MASTER_T;
    HAL_I2C_Master_Transmit(&hi2c1,SHT2x_ADDR, &mode, 1, 10);//(&hi2c1, SHT2x_ADDR, &mode, 1, 10)
    HAL_Delay(100);
    HAL_I2C_Master_Receive(&hi2c1,SHT2x_ADDR, i2cData, 2, 10);//(&hi2c1, SHT2x_ADDR, i2cData, 2, 10);
    val = i2cData[0] << 8 | i2cData[1];
    TEMP = -46.85 + 175.72 * ((float)val / 65536);
    lcdGotoXY(0,0);
    sprintf(str, "TEMP : %5.1lf", TEMP);
    lcdPrint(str);
    
    mode = SHT2x_NOHOLD_MASTER_RH;
    HAL_I2C_Master_Transmit(&hi2c1,SHT2x_ADDR, &mode, 1, 10);//(&hi2c1, SHT2x_ADDR, &mode, 1, 10)
    HAL_Delay(100);
    HAL_I2C_Master_Receive(&hi2c1,SHT2x_ADDR, i2cData, 2, 10);//(&hi2c1, SHT2x_ADDR, i2cData, 2, 10);
    val = i2cData[0] << 8 | i2cData[1];
    HUMI = -6 + 125 * ((float)val / 65536);
    lcdGotoXY(0,1);
    sprintf(str, "HUMI : %5.1lf", HUMI);
    lcdPrint(str);
    if(STOP == 1){
      lcdClear();
      STOP = 0;
      break;
    }
  }
}

void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
  if(huart->Instance == USART1) {
    HAL_UART_Receive_IT(&huart1, &rxData, 1);
    HAL_UART_Transmit(&huart1, &rxData, 1, 10);
  }
}

void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin)
{
  if(GPIO_Pin== GPIO_PIN_12){
    if(STOP == 0){
      STOP = 1;
    }
    
    else STOP = 0;
  }
}
/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */

  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{ 
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     tex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
