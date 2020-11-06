#include <Stepper.h>


const int stepPerRevolution = 2048;
Stepper myStepper(stepPerRevolution, 11, 9, 10, 8);

void setup(){
  myStepper.setSpeed(14);
}

void loop(){
  myStepper.step(stepPerRevolution);
  delay(500);
  
  myStepper.step(-stepPerRevolution);
  delay(500);
}
