using UnityEngine;
using System;
using System.IO.Ports;

public class Arduino : MonoBehaviour
{
    // Script that connects to, reads & writes to Arduino

    // Integer to specify which COM Port the Arduino is connected to
    [SerializeField]
    int commPort;

    // Creating an empty SerialPort variable
    private SerialPort serial = null;

    // public bool controllerActive = false;

    // On Start up, Unity will connect to the Arduino
    void Start()
    {
        ConnectToSerial();
    }

    void ConnectToSerial()
    {
        // Creates a new SerialPort that connects to the specified COM PORT, with a Baud rate of 9600
        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);

        // ReadTimeout of 50 milliseconds
        serial.ReadTimeout = 50;

        // Opens the Serial Connection
        serial.Open();

        Debug.Log("Connected to Arduino on port : " + commPort); // Simple Debug.Log that notifies the user that the arduino is connected
    }


    // Function that allows Unity to write to the Arduinos Serial Monitor
    // This will be used to activate the motors
    public void WriteToArduino(string motor) // Passes a string
    {
        serial.WriteLine(motor); // The string that is provided is then written to the Arduino
        serial.BaseStream.Flush(); // Flush() makes sure that all information in the buffer is sent to its destination
    }


    // This function makes sure that the Serial is closed
    // When the game is closed
    void OnDestroy()
    {
        Debug.Log("Exiting");
        serial.Close();
    }
}
