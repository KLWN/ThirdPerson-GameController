using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

#pragma warning disable


public class InputController : MonoBehaviour
{
    private Animator anim;
    private AnimatorClipInfo[] currentClipInfo;
    private Rigidbody rb;
    public Collider groundCollider;

    [Header("Aktuelles Movement:")] 
    [Space(10)] 
    [SerializeField] private float xzMovement;
    [SerializeField] private float yMovement;
    [SerializeField] private float rotation;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isFallingHigh;
    [SerializeField] private bool isAboutToLandFromHigh;

    [Header("Movement Einstellungen:")] 
    [Space(10)]
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 15.0f;
    public float jumpForce = 7.0f;
    public float backwardsMultiplier = 0.25f;
    private float mult;


    
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        groundCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        isGrounded = GroundDetection.grounded;
        isFallingHigh = HighFallDetection.fallingHigh;
        isAboutToLandFromHigh = HighFallDetection.aboutToLandFromHigh;
        
        Physics.gravity = new Vector3(0, -25, 0);

        if (xzMovement < 0)
        {
            mult = backwardsMultiplier;
            anim.SetBool("isWalkingBackwards", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
        }

        if (xzMovement == 0)
        {
            mult = backwardsMultiplier * 2f;
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalkingBackwards", false);
            anim.SetBool("isRunning", false);
        }

        if (xzMovement > 0)
        {
            mult = 1f;
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalkingBackwards", false);
        }
        

        transform.Translate(0, 0, xzMovement);
        transform.Rotate(0, rotation, 0);
        
        
        xzMovement = (Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime) * mult;
        rotation = (Input.GetAxis("Horizontal") * (rotationSpeed * 10f) * Time.deltaTime) * mult;

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isJumping");
            rb.velocity = new Vector3(0, jumpForce, 0);

        }
    }


}