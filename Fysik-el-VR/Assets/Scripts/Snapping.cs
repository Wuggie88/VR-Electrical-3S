﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    bool snapped = false;
    GameObject snapObject; // Object to snap.
    public bool isGrabbed = false;
    public float values = 0;
    public GameObject circuitBoard;
    Rigidbody snapBody;

    void Awake()
    {
        snapBody = snapObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (snapped == true)
        {
            snapObject.transform.position = transform.position;
        }

        if (isGrabbed)
        {
            snapped = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Component")
        {
            snapObject = other.gameObject;
            snapped = true;
            snapBody.isKinematic = true;

            values = snapObject.GetComponent<componentScript>().value;

            circuitBoard.GetComponent<CircuitScript>().setupComponent();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Component")
            snapBody.isKinematic = false;
    }

}
