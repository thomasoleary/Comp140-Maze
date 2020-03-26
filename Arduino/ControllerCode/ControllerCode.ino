/*
  * Author = Thomas O'Leary
  * GitHub Repo = https://www.github.com/thomasoleary/Comp140-Maze
  * License = GNU GPL 3.0
  * Copyright = Copyright (c) 2020 <Thomas O'Leary>
  * Full license agreement can be found in the LICENSE file or at <https://www.gnu.org/licenses/gpl-3.0.html>

  This .ino script is for both calculating the pitch & roll for the MPU6050
  and for taking input to activate the motors.

*/

#include <Wire.h>
#include <MPU6050.h>
MPU6050 mpu;

int pwmPorts[] = {3, 5, 6, 9};
int userInput;
int amountOfDelay = 100;

String userString;

Vector normalValue;


void setup() {
  Serial.begin(9600);
  
  for(int i = 0; i < 4; i++)
  {
    pinMode(pwmPorts[i], OUTPUT);
  }
    
  while(!mpu.begin(MPU6050_SCALE_2000DPS, MPU6050_RANGE_2G))
  {
      Serial.println("Could not find a valid MPU6050 sensor, check wiring!");
      delay(500);
  }
    

}

void loop() 
{
  if(Serial.available() > 0)
  {
    userString = Serial.read();

    userInput = userString.toInt();
    
    for(int x = 0; x < 4; x++)
    {
      if(x + 48 == userInput){
        RunMotor(x);
      }
    }
    
  }
  normalValue = mpu.readNormalizeAccel();

  int pitch = -(atan2(normalValue.XAxis, sqrt(normalValue.YAxis * normalValue.YAxis + normalValue.ZAxis * normalValue.ZAxis)) * 180.0) / M_PI;
  int roll = (atan2(normalValue.YAxis, normalValue.ZAxis) * 180.0) / M_PI;
  
  Serial.print(pitch);
  Serial.print("o");
  Serial.println(roll);

  delay(50);

}


void RunMotor(int x){
  //Serial.print("motor running");
  digitalWrite(pwmPorts[x], HIGH);
  delay(amountOfDelay);
  digitalWrite(pwmPorts[x], LOW);
  //delay(amountOfDelay);
  }
