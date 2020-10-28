using System.Collections;
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
        // get the material of the arch (the first one) and sets the emission color
        // Lav nyt lys til rammen, og smid det ind som doorArch i gameObject.
        archMaterial = doorArch.GetComponent<Renderer>().material;
        ColorUtility.TryParseHtmlString("#FF0000", out redGlow);
        archMaterial.SetColor("_EmissionColor", redGlow);
    }
    // Update is called once per frame
    void Update()
    {
        //the script that opens the door
        // this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(xPos, yPos, zPos), Time.deltaTime * speed);
    }

    // this should open the door, hopefully fully, else we can take a look at that (i have not been able to test this yet since my unity is an absolute asshole atm)
    public void doorOpen()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(xPos, yPos, zPos), Time.deltaTime * speed);
    }
}
