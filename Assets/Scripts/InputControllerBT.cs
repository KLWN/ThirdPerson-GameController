using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
#pragma warning disable

public class InputControllerBT : MonoBehaviour
{
    private static Animator m_Animator;
    private Rigidbody m_Rigidbody;

    private bool isRunning = false;
    public float vert;
    public float hori;
    public bool run;
    


    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {

        vert = Input.GetAxis("Vertical");
        hori = Input.GetAxis("Horizontal");
        run = Input.GetKeyDown(KeyCode.R);
        
        if (run)
        {
            isRunning = !isRunning;
        }

        
        if (!isRunning)
        {
            vert *= 0.5f;
        }
        
        
        m_Animator.SetFloat("Forward", vert, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("Turn", hori * 3, 0.1f, Time.deltaTime);

        if (Time.deltaTime > 0)
        {
            Vector3 velocity = m_Animator.deltaPosition / Time.deltaTime;
            m_Rigidbody.velocity = velocity;
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Animator.SetTrigger("isJumping");
        }
        

    }

    
    
    
}
