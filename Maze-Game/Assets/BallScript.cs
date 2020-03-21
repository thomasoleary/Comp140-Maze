using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : Arduino
{

    // Referencing all Trigger colliders on the Ball
    [SerializeField]
    GameObject frontTrigger;
    [SerializeField]
    GameObject leftTrigger;
    [SerializeField]
    GameObject rightTrigger;
    [SerializeField]
    GameObject backTrigger;


    // Creating booleans for each trigger to reference their individual BallTrigger.cs
    bool forwardCollision;
    bool leftCollision;
    bool rightCollision;
    bool backwardCollision;

    private void Update()
    {
        forwardCollision = frontTrigger.GetComponent<BallTrigger>().ballTriggered;
        leftCollision = leftTrigger.GetComponent<BallTrigger>().ballTriggered;
        rightCollision = rightTrigger.GetComponent<BallTrigger>().ballTriggered;
        backwardCollision = backTrigger.GetComponent<BallTrigger>().ballTriggered;


        // When a trigger is activated
        // It writes to the Arduino's serial
        // This will do a digitalWrite() to activate the assigned motor
        if (forwardCollision)
        {
            WriteToArduino("1"); // Activates front motor
        }
        if (leftCollision)
        {
            WriteToArduino("2"); // Activates left motor
        }
        if (rightCollision)
        {
            WriteToArduino("3"); // Activates right motor
        }
        if (backwardCollision)
        {
            WriteToArduino("4"); // Activates back motor
        }
    }

}
