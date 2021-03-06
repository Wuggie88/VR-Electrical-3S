﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningScript : MonoBehaviour
{
    // the speed the door should open with
    public float speed = 1;
    // the position of the door when open
    public float xPos;
    public float yPos;
    public float zPos;
    //the arch the door is in
    public GameObject doorArch;
    Material archMaterial;
    Color redGlow;

    private void Start()
    {
        //use this debug to find the position of the door
       //Debug.Log("door position: " + transform.position);

        // get the material of the arch (the first one) and sets the emission color
        // Lav nyt lys til rammen, og smid det ind som doorArch i gameObject.
        
        /*
        archMaterial = doorArch.GetComponent<Renderer>().material;
        ColorUtility.TryParseHtmlString("#FF0000", out redGlow);
        archMaterial.SetColor("_EmissionColor", redGlow);
        */
    }
    // Update is called once per frame
    void Update()
    {
        //the script that opens the door
        //this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(xPos, yPos, zPos), Time.deltaTime * speed);
    }

    // Opens the door when called (with help from other scripts)
    public void doorOpen()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(xPos, yPos, zPos), Time.deltaTime * speed);
    }
}
