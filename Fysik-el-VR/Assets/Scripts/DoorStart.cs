using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStart : MonoBehaviour
{

    public GameObject RDoor;
    public GameObject LDoor;


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DoorOpens());
        StartCoroutine(DoorOpens2());
    }

    IEnumerator DoorOpens()
    {
        do
        {
            RDoor.GetComponent<DoorOpeningScript>().doorOpen();
            yield return new WaitForEndOfFrame();
            //while the X-pos is not right (the axis that we open the door on)
        } while (RDoor.transform.position.x != RDoor.GetComponent<DoorOpeningScript>().xPos);

    }

    //sends signal to open the left door as long as it's not in "open" position
    IEnumerator DoorOpens2()
    {
        do
        {
            LDoor.GetComponent<DoorOpeningScript>().doorOpen();
            yield return new WaitForEndOfFrame();
            //while the X-pos is not right (the axis that we open the door on)
        } while (LDoor.transform.position.x != LDoor.GetComponent<DoorOpeningScript>().xPos);
    }
}
