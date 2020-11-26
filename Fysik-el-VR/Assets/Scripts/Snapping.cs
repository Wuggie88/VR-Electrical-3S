using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    bool snapped = false;
    GameObject snapObject; // Object to snap.
    private OVRGrabbable ovrGrabbable;
    public float values = 0;
    public GameObject circuitBoard;
    Rigidbody snapBody;

    void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (snapped == true)
        {
            snapObject.transform.position = transform.position;
            snapBody.isKinematic = true;
        }

        if (ovrGrabbable.isGrabbed)
            snapped = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Component")
        {
            snapObject = other.gameObject;
            snapBody = snapObject.GetComponent<Rigidbody>();
            snapped = true;

            values = snapObject.GetComponent<componentScript>().value;

            circuitBoard.GetComponent<CircuitScript>().setupComponent();

        }
    }

    // Kan være at denne metode skal fjernes og sætte (isKinematic = false) i isGrabbed funktionen i Update.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Component")
            snapBody.isKinematic = false;
    }

}
