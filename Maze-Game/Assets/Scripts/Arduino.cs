using UnityEngine;
using System;
using System.IO.Ports;
using System.Collections;

public class Arduino : MonoBehaviour
{
    /*
        * Author = Thomas O'Leary
        * GitHub Repo = https://www.github.com/thomasoleary/Comp140-Maze
        * License = GNU GPL 3.0
        * Copyright = Copyright (c) 2020 <Thomas O'Leary>
        * Full license agreement can be found in the LICENSE file or at <https://www.gnu.org/licenses/gpl-3.0.html>
        
        *** DISCLAIMER ***
        Originally, Arduino.cs, MoveMaze.cs and BallScript.cs were to work separately
        Due to complications with Reading and writing at the same time - I created ArduinoScript.cs
        ArduinoScript.cs has the functionality of all three scripts combined into one

        Script that connects to, reads & writes to Arduino
    */

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

        serial.WriteTimeout = 50;

        // Opens the Serial Connection
        serial.Open();
    }


    // Function that allows Unity to write to the Arduinos Serial Monitor
    // This will be used to activate the motors
    public void WriteToArduino(string motor) // Passes a string
    {
        Debug.Log(motor);
        //serial.WriteLine(motor); // The string that is provided is then written to the Arduino
        //serial.BaseStream.Flush(); // Flush() makes sure that all information in the buffer is sent to its destination
    }

    public string ReadFromArduino(int timeout = 0)
    {
        serial.ReadTimeout = timeout;
        try
        {
            return serial.ReadLine();
        }
        catch (TimeoutException e)
        {
            return null;
        }
    }


    // This function makes sure that the Serial is closed
    // When the game is closed
    void OnDestroy()
    {
        Debug.Log("Exiting");
        serial.Close();
    }
}
