﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject RDoor;
    public GameObject LDoor;
    public GameObject CircuitBoard;


    // Start is called before the first frame update
    void Start()
    {
        
        //test til at dørene virker
        /* 
        if (CircuitBoard.GetComponent<CircuitScript>().doorpoints == 4)
        {
            StartCoroutine(DoorOpens());
            StartCoroutine(DoorOpens2());
            Debug.Log("R door x: " + RDoor.transform.position.x);
            Debug.Log("R door y: " + RDoor.transform.position.y);
            Debug.Log("R door z: " + RDoor.transform.position.z);

            Debug.Log("L door x: " + LDoor.transform.position.x);
            Debug.Log("L door y: " + LDoor.transform.position.y);
            Debug.Log("L door z: " + LDoor.transform.position.z);
        }
        */
    }

    public void OnTriggerEnter(Collider other)
    {
        //checks if the circuitboard is correct, then starts the couroutines for opening the doors.
        
        if (CircuitBoard.GetComponent<CircuitScript>().doorpoints == 4)
        {
            StartCoroutine(DoorOpens());
            StartCoroutine(DoorOpens2());

        }
        
    }

    //sends signal to open the right door as long as it's not in "open" position
    IEnumerator DoorOpens()
    {
        do
        {
            RDoor.GetComponent<DoorOpeningScript>().doorOpen();
            yield return new WaitForEndOfFrame();
            //while the X-pos is not right (the axis that we open the door on)
        } while (RDoor.transform.position.x != RDoor.GetComponent<DoorOpeningScript>().xPos);

    }

    //sends signal to open the left door as long as it's not in "open" position
    IEnumerator DoorOpens2()
    {
        do
        {
            LDoor.GetComponent<DoorOpeningScript>().doorOpen();
            yield return new WaitForEndOfFrame();
            //while the X-pos is not right (the axis that we open the door on)
        } while (LDoor.transform.position.x != LDoor.GetComponent<DoorOpeningScript>().xPos);
    }
}
