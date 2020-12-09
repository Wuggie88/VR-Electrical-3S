using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSnapping : MonoBehaviour
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

    public GameObject hint;

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
            snapBody.useGravity = false;
        }

        if (ovrGrabbable != null && ovrGrabbable.isGrabbed)
        {
            snapped = false;
            snapBody.useGravity = true;
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

                circuitBoard.GetComponent<IntroCircuitScript>().setupComponent();
                hint.SetActive(false);
            }
            else if (componentType == ComponentType.OtherComponent && other.tag == "Component")
            {
                snapObject = other.gameObject;
                snapBody = snapObject.GetComponent<Rigidbody>();
                snapped = true;
                ovrGrabbable = other.GetComponent<OVRGrabbable>();

                values = snapObject.GetComponent<componentScript>().value;

                circuitBoard.GetComponent<IntroCircuitScript>().setupComponent();
                hint.SetActive(false);
            }
            hasSnapObject = true;
        }
        else { return; }
    }

    void OnTriggerExit(Collider other)
    {
        hasSnapObject = false;
    }
}
