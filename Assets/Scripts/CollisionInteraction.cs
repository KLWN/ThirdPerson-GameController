using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInteraction : MonoBehaviour
{

    public Transform door;
    public Vector3 openedDoor = new Vector3(7.3f, 7.2f, -7.3f);
    public Vector3 closedDoor = new Vector3(7.3f, 3.6f, -7.3f);
    public float openSpeed = 5f;
    public bool openDoor;

    

    private void Update()
    {
        if (openDoor)
        {
            door.position = Vector3.Lerp(door.position, openedDoor, Time.deltaTime * openSpeed);
        }
        else
        {
            door.position = Vector3.Lerp(door.position, closedDoor, Time.deltaTime * openSpeed);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            OpenDoor();
            Debug.Log("Open Door");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            CloseDoor();
            Debug.Log("Door Closed");
        }
    }


    private void CloseDoor()
    {
        openDoor = false;
    }

    private void OpenDoor()
    {
        openDoor = true;
    }
    
    
}