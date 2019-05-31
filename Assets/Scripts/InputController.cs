using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
#pragma warning disable

public class InputController : MonoBehaviour
{
    private static Animator anim;
    private float translation;
    private float rotation;
    [Space(10)]
    [Header("Grundeinstellungen:")]
    public float movementSpeed = 10.0f;
    public int movementMultiplier = 1;
    [Space(5)]
    public float rotationSpeed = 100.0f;
    public int rotationMultiplier = 1;
    



    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        translation = Input.GetAxis("Vertical") * movementSpeed;
        rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        
        translation *= Time.deltaTime * movementMultiplier;
        rotation *= Time.deltaTime * rotationMultiplier;
        
        transform.Translate(0, 0, translation); //Bewegung nur über die Z-Achse
        transform.Rotate(0, rotation, 0); //Rotation nur über die Y-Achse
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isJumping");
        }


        if (translation != 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }
        
        
    }
}
