using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : Arduino
{
    [SerializeField]
    private GameObject[] TriggerArray = new GameObject[4];

    public int arrayIndex;

    private void Start()
    {
        TriggerArray = GameObject.FindGameObjectsWithTag("Trigger");
    }

    private void Update()
    {
        for(int x = 0; x < 4; x++)
        {
            if(TriggerArray[x].GetComponent<BallTrigger>().ballTriggered == true)
            {
                arrayIndex = x;
                // Debug.Log("Motor " + arrayIndex + " running");
            }
        }
        
    }

}
