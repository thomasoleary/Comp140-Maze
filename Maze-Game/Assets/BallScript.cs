using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : Arduino
{
    [SerializeField]
    GameObject frontTrigger;
    [SerializeField]
    GameObject leftTrigger;
    [SerializeField]
    GameObject rightTrigger;
    [SerializeField]
    GameObject backTrigger;


    private void FixedUpdate()
    {
        if (frontTrigger.GetComponent<BallTrigger>().ballTriggered)
        {
            Debug.Log("Front trigger is triggered");
            WriteToArduino("1");
        }
        if (leftTrigger.GetComponent<BallTrigger>().ballTriggered)
        {
            Debug.Log("Left trigger is triggered");
            WriteToArduino("2");
        }
        if (rightTrigger.GetComponent<BallTrigger>().ballTriggered)
        {
            Debug.Log("Right trigger is triggered");
            WriteToArduino("3");
        }
        if (backTrigger.GetComponent<BallTrigger>().ballTriggered)
        {
            Debug.Log("Back trigger is triggered");
            WriteToArduino("4");
        }
    }

}
