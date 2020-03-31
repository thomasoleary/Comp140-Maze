using System.Collections;
using UnityEngine;
using System.IO.Ports;
using System;

public class ArduinoScript : MonoBehaviour
{
    [SerializeField]
    int commPort;
    private SerialPort serial = null;


    [SerializeField]
    bool isControllerActive;
    [SerializeField]
    GameObject maze;
    [SerializeField]
    GameObject playerBall;

    [SerializeField]
    private GameObject[] TriggerArray = new GameObject[4];
    public int arrayIndex = 5;

    void Start()
    {
        ConnectToSerial();


        playerBall = GameObject.FindGameObjectWithTag("Player");


        TriggerArray = GameObject.FindGameObjectsWithTag("Trigger");
    }

    void Update()
    {
        if (isControllerActive)
        {
            for (int x = 0; x < 4; x++)
            {
                if (TriggerArray[x].GetComponent<BallTrigger>().ballTriggered == true)
                {
                    arrayIndex = x;
                    break;
                    //Debug.Log("Motor " + arrayIndex + " running");
                }
            }

            string indexString = playerBall.GetComponent<BallScript>().arrayIndex.ToString();
            WriteToArduino(indexString);

            string value = ReadFromArduino(50);

            if (value != null)
            {
                //pitchoroll
                string[] values = value.Split('o');

                if (values.Length == 2)
                {
                    MazeMovement(values);
                }
            }
        }
    }

    void ConnectToSerial()
    {
        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.WriteTimeout = 50;
        serial.Open();
    }

    public void WriteToArduino(string motor)
    {
        Debug.Log(motor);
        serial.WriteLine(motor);
        serial.BaseStream.Flush();
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

    void OnDestroy()
    {
        Debug.Log("Exiting");
        serial.Close();
    }

    void MazeMovement(string[] values)
    {
        // Roll
        float xRotation = RemapValues(int.Parse(values[1]), -90f, 90f, -30f, 30f);

        // Pitch
        float zRotation = RemapValues(int.Parse(values[0]), -90f, 90f, -30f, 30f);

        maze.transform.rotation = Quaternion.Euler(xRotation, transform.rotation.y, zRotation);
    }

    float RemapValues(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
