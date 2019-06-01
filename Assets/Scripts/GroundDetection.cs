using System;
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class GroundDetection : MonoBehaviour
 {
     public static bool grounded = true;


     private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Ground"))
         {
             if (!grounded)
             {
                 grounded = true;
                 //Debug.Log("Grounded");
             }
         }
     }
 
     private void OnTriggerExit(Collider other)
     {
         if (other.CompareTag("Ground"))
         {
             if (grounded)
             {
                 grounded = false;
                 //Debug.Log("not Grounded - Small Jump");
             }
         }
     }
     
     
 }