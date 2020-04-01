using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaze : Arduino
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

        Script that reads the pitch and roll values that are given from the Arduino
    */

    [SerializeField]
    bool isControllerActive;

    [SerializeField]
    GameObject maze;

    [SerializeField]
    GameObject playerBall;

    private void Start()
    {
        playerBall = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (isControllerActive)
        {
            //string indexString = playerBall.GetComponent<BallScript>().arrayIndex.ToString();
            //WriteToArduino(indexString);

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
