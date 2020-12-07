﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    GameObject snapObject; // Object to snap.
    Rigidbody snapBody;

    bool hasSnapObject = false;
    bool snapped = false;
    private OVRGrabbable ovrGrabbable;

    public float values = 0;
    public GameObject circuitBoard;

    public enum ComponentType { Battery, OtherComponent }
    public ComponentType componentType;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (snapped == true)
        {
            snapObject.transform.position = transform.position;
            snapObject.transform.rotation = transform.rotation;
            
        }

        if (ovrGrabbable != null && ovrGrabbable.isGrabbed)
        {
            snapped = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasSnapObject == false)
        {
            if (componentType == ComponentType.Battery && other.tag == "Battery")
            {
                snapObject = other.gameObject;
                snapBody = snapObject.GetComponent<Rigidbody>();
                snapped = true;
                ovrGrabbable = other.GetComponent<OVRGrabbable>();

                values = snapObject.GetComponent<componentScript>().value;

                circuitBoard.GetComponent<CircuitScript>().setupComponent();
                snapBody.useGravity = false;
            }
            else if (componentType == ComponentType.OtherComponent && other.tag == "Component")
            {
                snapObject = other.gameObject;
                snapBody = snapObject.GetComponent<Rigidbody>();
                snapped = true;
                ovrGrabbable = other.GetComponent<OVRGrabbable>();

                values = snapObject.GetComponent<componentScript>().value;

                circuitBoard.GetComponent<CircuitScript>().setupComponent();
                snapBody.useGravity = false;
            }
            hasSnapObject = true;
        }
        else { return; }
    }

    void OnTriggerExit(Collider other)
    {
        hasSnapObject = false;
        snapBody.useGravity = true;
    }
}
