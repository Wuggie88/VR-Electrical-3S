using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemAdd : MonoBehaviour
{
    int AddingHealth;
    private int DeSpawnTime = 2;
    private OVRGrabbable ovrGrabbable;


    // Start is called before the first frame update
    void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrGrabbable.isGrabbed)
        {

        }
    }
}
