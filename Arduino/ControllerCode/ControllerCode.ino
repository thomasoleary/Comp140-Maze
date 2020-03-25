#include <MPU6050.h>
#include <Wire.h>

MPU6050 mpu;

int pwmPorts[] = {3, 5, 6, 9};
int userInput;

int amountOfDelay = 100;


void setup() {
  Serial.begin(9600);
  // put your setup code here, to run once:
  for(int i = 0; i < 4; i++){
    pinMode(pwmPorts[i], OUTPUT);
    }

}

void loop() {
  if(Serial.available() > 0){
    userInput = Serial.read();

    for(int x = 0; x < 4; x++){
      if(pwmPorts[x] == userInput){
        RunMotor(x);
        }
      }
    }

}


void RunMotor(int x){
  digitalWrite(pwmPorts[x], HIGH);
  delay(amountOfDelay);
  digitalWrite(pwmPorts[x], LOW);
  //delay(amountOfDelay);
  }
