using System.Collections;
using UnityEngine;
using System.IO.Ports;
using System;

public class ArduinoScript : MonoBehaviour
{
    /*
        * Author = Thomas O'Leary
        * GitHub Repo = https://www.github.com/thomasoleary/Comp140-Maze
        * License = GNU GPL 3.0
        * Copyright = Copyright (c) 2020 <Thomas O'Leary>
        * Full license agreement can be found in the LICENSE file or at <https://www.gnu.org/licenses/gpl-3.0.html>
         
        This script controls the entirety of the project
        Within this script it connects, writes and reads to the arduino
        Also controls the Maze's movement
    */


    // COM Port relatated variable set-up
    [SerializeField]
    // Integer to specify which COM Port the Arduino is connected to
    int commPort;
    private SerialPort serial = null; 


    // Maze Movement variable set-up
    [SerializeField]
    // Serialized bool to allow the user to say if the controller is on or not
    bool isControllerActive; 
    [SerializeField]
    GameObject maze; // Reference the maze GameObject
    GameObject playerBall; // Ball GameObject


    // Ball related variable set-up
    [SerializeField] // Only set to Serialized for debugging purposes
    // Create a new array with the size of 4
    private GameObject[] TriggerArray = new GameObject[4];
    // This integer will be passed to WriteToArduino()
    public int arrayIndex = 5; 

    void Start()
    {
        ConnectToSerial();

        // Assign GameObject with tag to playerBall
        playerBall = GameObject.FindGameObjectWithTag("Player"); 

        // Find GameObjects with tag "Trigger" and add them to TriggerArray
        TriggerArray = GameObject.FindGameObjectsWithTag("Trigger");
    }

    void Update()
    {
        if (isControllerActive)
        {
            // For loop to loop around TriggerArray
            for (int x = 0; x < 4; x++)
            {
                // If any of the Triggers are set to true
                if (TriggerArray[x].GetComponent<BallTrigger>().ballTriggered == true) 
                {
                    arrayIndex = x; // This integer will be passed to WriteToArduino
                    break;
                    //Debug.Log("Motor " + arrayIndex + " running");
                }
            }

            // Converting arrayIndex to a string
            string indexString = playerBall.GetComponent<BallScript>().arrayIndex.ToString();
            
            // Write to the COM port
            WriteToArduino(indexString);

            // Read from Arduino and apply it to value
            string value = ReadFromArduino(50);

            // This splits the Accelerometer values provided from the Arduino
            // In ControllerCode.ino it prints them as "PitchValueoRollValue"
            // Separating them with 'o'
            if (value != null)
            {
                //pitchoroll becomes values['pitch value', 'roll value']
                // e.g. -20o30 becomes values['-20', '30']
                string[] values = value.Split('o');

                if (values.Length == 2)
                {
                    // Pass pitch and roll values to MazeMovement()
                    MazeMovement(values);
                }
            }
        }
    }

    void ConnectToSerial()
    {
        // Simple function that connects to the desired COM Port
        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.WriteTimeout = 50;
        serial.Open();
    }

    public void WriteToArduino(string motor)
    {
        // Debug.Log(motor);
        // Writes to the COM Port what motor to run
        serial.WriteLine(motor);
        // Flush() makes sure that all information in the buffer is sent to its destination
        serial.BaseStream.Flush();
    }

    public string ReadFromArduino(int timeout = 0)
    {
        // ReadTimeout now becomes whatever value has been passed when the ReadFromArduino is called
        serial.ReadTimeout = timeout;
        try
        {
            return serial.ReadLine(); // string value now is equal to whatever serial.ReadLine() returns
        }
        catch (TimeoutException e)
        {
            return null; // Returns null if it timesout
        }
    }

    void OnDestroy()
    {
        // Makes sure that the Serial Port is closed when the Game ends
        Debug.Log("Exiting");
        serial.Close();
    }

    void MazeMovement(string[] values) // Takes in an array
    {
        // Limit the values from -90f to 90f
        // And sets them to -30f to 30f
        
        // Roll
        float xRotation = RemapValues(int.Parse(values[1]), -90f, 90f, -30f, 30f);

        // Pitch
        float zRotation = RemapValues(int.Parse(values[0]), -90f, 90f, -30f, 30f);

        // Sets the new remapped values to the rotation of the maze

        // Roll controls the X rotation and pitch controls the Z rotation
        maze.transform.rotation = Quaternion.Euler(xRotation, transform.rotation.y, zRotation);
    }

    float RemapValues(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
