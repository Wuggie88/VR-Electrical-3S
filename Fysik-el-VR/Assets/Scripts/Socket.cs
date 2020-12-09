using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    bool snapped = false;
    GameObject snapObject; // Object to snap.
    private OVRGrabbable ovrGrabbable;
    public float values = 0;
    public GameObject beltpoint;
    Rigidbody snapBody;

    // Update is called once per frame
    void Update()
    {
        if (snapped == true)
        {
            snapObject.transform.position = transform.position;
        }

        if (ovrGrabbable != null && ovrGrabbable.isGrabbed)
        {
            snapped = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            snapObject = other.gameObject;
            snapBody = snapObject.GetComponent<Rigidbody>();
            snapped = true;
            snapBody.useGravity = false;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "weapon")
            snapBody.useGravity = true;
    }

}