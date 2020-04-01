using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{    
    /*
        * Author = Thomas O'Leary
        * GitHub Repo = https://www.github.com/thomasoleary/Comp140-Maze
        * License = GNU GPL 3.0
        * Copyright = Copyright (c) 2020 <Thomas O'Leary>
        * Full license agreement can be found in the LICENSE file or at <https://www.gnu.org/licenses/gpl-3.0.html>
         
    */

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
