using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaze : Arduino
{
    [SerializeField]
    bool isControllerActive;

    [SerializeField]
    GameObject maze;

    void Update()
    {
        if (isControllerActive)
        {
            string value = ReadFromArduino(50);

            if(value != null)
            {
                //pitchoroll
                string[] values = value.Split('o');

                if(values.Length == 2)
                {
                    MazeMovement(values);
                }
            }
        }
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
