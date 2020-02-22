using UnityEngine;
using System;
using System.IO.Ports;

public class Arduino : MonoBehaviour
{

    [SerializeField]
    private int commPort = 0;

    private SerialPort serial = null;

    void Start()
    {
        ConnectToSerial();
    }

    void ConnectToSerial()
    {
        Debug.Log("Attempting Serial: " + commPort);

        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.Open();
    }

    void WriteToArduino(string motor)
    {
        serial.WriteLine(motor);
        serial.BaseStream.Flush();
    }

    void OnDestroy()
    {
        Debug.Log("Exiting");
        serial.Close();
    }
}
