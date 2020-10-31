using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject RDoor;
    public GameObject LDoor;
    public GameObject CircuitBoard;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        //checks if the circuitboard is correct, then starts the couroutines for opening the doors.
        if (CircuitBoard.GetComponent<CircuitScript>().doorpoints == 4)
        {
            StartCoroutine(DoorOpens());
            StartCoroutine(DoorOpens2());

        }
    }

    //sends signal to open the right door as long as it's not in "open" position
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
