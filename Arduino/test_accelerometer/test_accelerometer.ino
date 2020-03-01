#include <Wire.h>

// Importing MPU6050 library
// Available at: https://github.com/jrowberg/i2cdevlib/tree/master/Arduino/MPU6050
#include <MPU6050.h> 


MPU6050 mpu;

void setup() {
  // put your setup code here, to run once:

  Serial.begin(115200);
  // Serial.println("Initialize MPU6050");

  while(!mpu.begin(MPU6050_SCALE_2000DPS, MPU6050_RANGE_2G))
  {
    Serial.println("Could not find a valid MPU6050 sensor, check wiring!");
    delay(500);
  }

}


void loop()
{
  // Read normalized values
  Vector normAccel = mpu.readNormalizeAccel();

  // Calculate Pitch & Roll
  int pitch = -(atan2(normAccel.XAxis, sqrt(normAccel.YAxis * normAccel.YAxis + normAccel.ZAxis * normAccel.ZAxis)) * 180.0) / M_PI;
  int roll = (atan2(normAccel.YAxis, normAccel.ZAxis) * 180.0) / M_PI;

  Serial.print(pitch);
  Serial.print("o");
  Serial.println(roll);

  Serial.println();

  delay(50);
}
