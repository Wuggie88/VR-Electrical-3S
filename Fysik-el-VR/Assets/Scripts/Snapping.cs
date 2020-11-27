using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    GameObject snapObject; // Object to snap.
    Rigidbody snapBody;

    bool snapped = false;
    private OVRGrabbable ovrGrabbable;

    public float values = 0;
    public GameObject circuitBoard;

    public enum ComponentType { Battery, OtherComponent }
    public ComponentType componentType;

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
            snapObject.transform.rotation = transform.rotation;
            snapBody.useGravity = false;
        }

        if (ovrGrabbable.isGrabbed)
        {
            snapped = false;
            snapBody.useGravity = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (componentType == ComponentType.Battery && other.tag == "Battery")
        {
            snapObject = other.gameObject;
            snapBody = snapObject.GetComponent<Rigidbody>();
            snapped = true;

            values = snapObject.GetComponent<componentScript>().value;

            circuitBoard.GetComponent<CircuitScript>().setupComponent();
        }
        else if (componentType == ComponentType.OtherComponent && other.tag == "Component")
        {
            snapObject = other.gameObject;
            snapBody = snapObject.GetComponent<Rigidbody>();
            snapped = true;

            values = snapObject.GetComponent<componentScript>().value;

            circuitBoard.GetComponent<CircuitScript>().setupComponent();
        }

    }

}
