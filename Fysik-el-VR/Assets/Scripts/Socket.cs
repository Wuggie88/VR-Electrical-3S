using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    bool snapped = false;
    GameObject snapObject; // Object to snap.
    public bool isGrabbed = false;
    public float values = 0;
    public GameObject beltpoint;
    Rigidbody snapBody;

    // Update is called once per frame
    void Update()
    {
        if (snapped == true)
        {
            snapObject.transform.position = transform.position;
            snapBody.isKinematic = true;
        }

        if (isGrabbed)
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

            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "weapon")
            snapBody.isKinematic = false;
    }

}
