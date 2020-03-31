using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    // This is a script that applies to all triggers
    // that are children of the Ball object

    // Creating a public bool that will be accessed in BallScript.cs
    // This bool will vary on each trigger
    // Allowing the arduino to activate the different motors

    // Automatically set to false (otherwise the motor will turn on instantly)
    public bool ballTriggered = false;



    // When the wall enters the trigger
    // Bool is set to true
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            ballTriggered = true;
        }
    }

    // When the wall leaves the trigger
    // Bool is set back to false
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "wall")
        {
            ballTriggered = false;
        }
    }
}
