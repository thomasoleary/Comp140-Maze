using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    
    public int motorInteger;

    private string motorNumber;

    public bool ballTriggered = false;

    private void Start()
    {
        motorNumber = motorInteger.ToString();
        Debug.Log(motorNumber);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            ballTriggered = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "wall")
        {
            ballTriggered = false;
        }
    }
}
