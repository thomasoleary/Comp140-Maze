#include <SoftwareSerial.h>

SoftwareSerial MyBluetooth(10, 11); // RX / TX

String wordOutput;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  MyBluetooth.begin(9600);

  Serial.println("Non-bluetooth hello there");
  MyBluetooth.println("Bluetooth hello there");

}

void loop() {
  // put your main code here, to run repeatedly:
  if (MyBluetooth.available())
  {
    wordOutput = MyBluetooth.read();
  }
  else
  {
    MyBluetooth.print(wordOutput);
  }

  if(Serial.available())
    Serial.write(Serial.read());
    

}
