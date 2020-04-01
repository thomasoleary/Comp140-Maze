/*
  * Author = Thomas O'Leary
  * GitHub Repo = https://www.github.com/thomasoleary/Comp140-Maze
  * License = GNU GPL 3.0
  * Copyright = Copyright (c) 2020 <Thomas O'Leary>
  * Full license agreement can be found in the LICENSE file or at <https://www.gnu.org/licenses/gpl-3.0.html>

  This .ino script is for both calculating the pitch & roll for the MPU6050
  and for taking input to activate the motors.

*/

// The wire library is used for I2C communication (for the MPU6050)
#include <Wire.h>

// This MPU6050 library was created by GitHub user jarzebski
// https://github.com/jarzebski/Arduino-MPU6050
#include <MPU6050.h>

MPU6050 mpu;

// Creating an array and initialising all PWM ports
// that the motors are using to it
int pwmPorts[] = {3, 5, 6, 9};

// String & Integer that will be used for Input from the user
int userInput;
String userString;

// Integer that will be used for delay (in milliseconds)
int amountOfDelay = 100;

// Vector value that is used to get Normalised Values from the MPU6050
Vector normalValue;


void setup() {
  // Setting the Serial to baud rate of 115200
  Serial.begin(115200);

  // For loop to create 4 pinModes
  // (One for every PWM Port)
  for(int i = 0; i < sizeof(pwmPorts); i++)
  {
    pinMode(pwmPorts[i], OUTPUT);
  }

  // MPU6050.begin is a bool function
  // This while loop checks to see if there is an MPU6050 for the library to use
  // But also resets all ots calibrated and threshold values
  // Once all tasks are done, the bool is returned as true
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
    // Sets userString to any value typed into the serial monitor
    userString = Serial.read();

    userInput = userString.toInt();

    // Simple for loop, looping pwmPorts[]
    // To check if userInput is equal to x
    for(int x = 0; x < 4; x++)
    {
      if(x + 48 == userInput){
        // Run this function passing the value of x
        RunMotor(x);
      }
    }
    
  }

  // Using the Vector to normalise the values
  // This function firstly reads all Raw Data from the MPU6050
  // And sets all Axis to: (X, Y or Z) * MPU6050_RANGE_2G (which is .000061f) * 9.8xxxf
  normalValue = mpu.readNormalizeAccel();

  // Calculates pitch & roll values using the normalised values and trig (Arc Tangents)
  int pitch = -(atan2(normalValue.XAxis, sqrt(normalValue.YAxis * normalValue.YAxis + normalValue.ZAxis * normalValue.ZAxis)) * 180.0) / M_PI;
  int roll = (atan2(normalValue.YAxis, normalValue.ZAxis) * 180.0) / M_PI;

  // Printing pitch & roll values to serial monitor
  // This is so Unity can read these values
  Serial.print(pitch);
  Serial.print("o");
  Serial.println(roll);

  delay(amountOfDelay);

}

// RunMotor function
void RunMotor(int x){
  // Serial.print("motor running");

  // Runs the specific pwmPort in the array
  digitalWrite(pwmPorts[x], HIGH);
  delay(amountOfDelay);
  digitalWrite(pwmPorts[x], LOW);
  }
