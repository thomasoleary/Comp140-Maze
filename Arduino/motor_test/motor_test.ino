const int motor1 = 3;
const int motor2 = 5;
const int motor3 = 6;
const int motor4 = 9;

int userInput;

int amountOfDelay = 100; // Delay integer that can be adjusted (in milliseconds)

void setup() {
  Serial.begin(9600);
  pinMode(motor1, OUTPUT);
  pinMode(motor2, OUTPUT);
  pinMode(motor3, OUTPUT);
  pinMode(motor4, OUTPUT);

}

void loop() {
  if (Serial.available() > 0){
    userInput = Serial.read();

    if(userInput == '1'){
      motorOne();
    }
    if(userInput == '2'){
      motorTwo();
    }
    if(userInput == '3'){
      motorThree();
    }if(userInput == '4'){
      motorFour();
    }
  }

}

void motorOne(){
  digitalWrite(motor1, HIGH);
  delay(amountOfDelay);
  digitalWrite(motor1, LOW);
  //delay(amountOfDelay);
}

void motorTwo(){
  digitalWrite(motor2, HIGH);
  delay(amountOfDelay);
  digitalWrite(motor2, LOW);
  //delay(amountOfDelay);
}

void motorThree(){
  digitalWrite(motor3, HIGH);
  delay(amountOfDelay);
  digitalWrite(motor3, LOW);
  //delay(amountOfDelay);
}

void motorFour(){
  digitalWrite(motor4, HIGH);
  delay(amountOfDelay);
  digitalWrite(motor4, LOW);
  //delay(amountOfDelay);
}
