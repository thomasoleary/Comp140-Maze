using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public bool ballTriggered = false;

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
