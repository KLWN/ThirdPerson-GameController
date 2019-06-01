using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
#pragma warning disable



public class InputControllerRM : MonoBehaviour
{
    private static Animator Animator;
    private Rigidbody Rigidbody;
    private bool isRunning = false;
    public float vert;
    public float hori;
    public int rotationMultiplier = 100;
    private Vector3 EulerAngleVelocity;
    
    
    private void Start()
    {
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        vert = Input.GetAxis("Vertical");
        hori = Input.GetAxis("Horizontal");


        if (hori <= 0.1)
        {
            Animator.SetBool("isIdle", true);
        }

        if (hori > 0.1)
        {
            Animator.SetBool("isIdle", false);
        }
        
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRunning = !isRunning;
        }
        
        if (!isRunning)
        {
            vert *= 0.5f;
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animator.SetTrigger("isJumping");
        }
        
        
        Animator.SetFloat("Forward", vert, 0.1f, Time.deltaTime);
        Animator.SetFloat("Turn", hori * 2, 0.1f, Time.deltaTime);
        
        
        Vector3 velocity = Animator.deltaPosition / Time.deltaTime;
        Rigidbody.velocity = velocity;
            
            
        EulerAngleVelocity = new Vector3(0, hori * rotationMultiplier, 0);
        Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.deltaTime);
        Rigidbody.MoveRotation(Rigidbody.rotation * deltaRotation);
        
    }
    
    
}
