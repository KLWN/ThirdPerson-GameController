using System;
using System.Collections;
using System.Collections.Generic;
using Unity.UNetWeaver;
using UnityEditor;
using UnityEngine;
#pragma warning disable
 
 public class GroundDetection : MonoBehaviour
 {
     private Vector3 playerPosDown;
     private Vector3 playerPosFwd;
     private RaycastHit hitDown;
     private RaycastHit hitFwd;

     [Header("Raycast Einstellungen:")]
     public Vector3 rayDown = Vector3.down;
     public float rayDownDistance = 5.0f;
     public float rayDownYOffset = 0.1f;
     public float rayDownYHitThreshold = 0.2f;
     public int rayDownHitLayerMask = 9;
     public Color rayDownColor = Color.red;
     [Space(5)] 
     public Vector3 rayFwd;
     public float rayFwdDistance = 3.0f;
     public float rayFwdYOffset = 1.0f;
     public float rayFwdHitThreshold = 1.0f;
     public int rayFwdHitLayerMask = 10;
     public Color rayFwdColor = Color.blue;
     
     [Header("Raycast Feedback:")]
     public float rayDownHitDistance;
     public float rayFwdHitDistance;
     [Space(5)]
     public bool isGrounded;
     public bool objectAhead;
     
     

     private void FixedUpdate()
     {
         
         // Fixed-TimeStep ist aktuell 0.01, 100fps (Standard: 0.02, 50fps)
         
         playerPosDown = new Vector3(transform.position.x, transform.position.y + rayDownYOffset, transform.position.z);
         playerPosFwd = new Vector3(transform.position.x, transform.position.y + rayFwdYOffset, transform.position.z);
 
         

         rayDownHitDistance = hitDown.distance;
         Debug.DrawRay(playerPosDown,rayDown * rayDownDistance, rayDownColor);
         Physics.Raycast(playerPosDown, rayDown, out hitDown, rayDownDistance, 1 << rayDownHitLayerMask);
         
         
         
         rayFwd = transform.forward;
         rayFwdHitDistance = hitFwd.distance;
         Debug.DrawRay(playerPosFwd,rayFwd * rayFwdDistance, rayFwdColor);
         Physics.Raycast(playerPosFwd, rayFwd, out hitFwd, rayFwdDistance, 1 << rayFwdHitLayerMask);


      
         

         if (rayDownHitDistance < rayDownYHitThreshold)
         {
             isGrounded = true;
         }
         else
         {
             isGrounded = false;
         }
         
         
         if (rayFwdHitDistance > rayFwdHitThreshold)
         {
             objectAhead = true;
         }
         else
         {
             objectAhead = false;
         }
         

     }

     
     
 }