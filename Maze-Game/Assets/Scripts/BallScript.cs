using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : Arduino
{    
    /*
        * Author = Thomas O'Leary
        * GitHub Repo = https://www.github.com/thomasoleary/Comp140-Maze
        * License = GNU GPL 3.0
        * Copyright = Copyright (c) 2020 <Thomas O'Leary>
        * Full license agreement can be found in the LICENSE file or at <https://www.gnu.org/licenses/gpl-3.0.html>
         
    */

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
                break;
                //Debug.Log("Motor " + arrayIndex + " running");
            }
        }
        
    }

}
