using System.Collections;
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
        // checks if the snapping bool is true, which will snap the component to its snappoint.
        if (snapped == true)
        {
            snapObject.transform.position = transform.position;
            snapObject.transform.rotation = transform.rotation;
            
        }

        // checks if the component is grabbed by the vr controller, to release it from being snapped.
        if (ovrGrabbable != null && ovrGrabbable.isGrabbed)
        {
            snapped = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // checks if there already is an object snapped to the snappoint.
        if (!hasSnapObject)
        {
            // if there isn't an object it will check if the snappoints type is the same as the objects tag.
            if (componentType == ComponentType.Battery && other.tag == "Battery")
            {
                // here it then sets the object as the snapped object, and calls the method Snap()
                snapObject = other.gameObject;
                Snap(snapObject);
            }
            else if (componentType == ComponentType.OtherComponent && other.tag == "Component")
            {
                snapObject = other.gameObject;
                Snap(snapObject);
            }
            hasSnapObject = true;
        }
        else { return; }
    }

    void OnTriggerExit(Collider other)
    {
        // when the object leaves the snappoint, its physics is returned to normal
        hasSnapObject = false;
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    void Snap(GameObject snapObject)
    {
        // here we get the objects components and sets the obejects gravity to false
        snapBody = snapObject.GetComponent<Rigidbody>();
        snapBody.useGravity = false;
        ovrGrabbable = snapObject.GetComponent<OVRGrabbable>();

        snapped = true;

        // here we get the value of the component, which we use for the calculation
        values = snapObject.GetComponent<componentScript>().value;
        circuitBoard.GetComponent<CircuitScript>().setupComponent();

    }
}
