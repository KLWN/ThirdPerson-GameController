using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFallDetection : MonoBehaviour
{
    public static bool fallingHigh = false;
    public static bool aboutToLandFromHigh = false;

    
    private void Update()
    {
        if (GroundDetection.grounded)
        {
            fallingHigh = false;
            aboutToLandFromHigh = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (!aboutToLandFromHigh)
            {
                aboutToLandFromHigh = true;
                //Debug.Log("Grounded - from High Fall");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!fallingHigh)
        {
            fallingHigh = true;
            //Debug.Log("Grounded - from High Fall");
        }
    }
    
    
}