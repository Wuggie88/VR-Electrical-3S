using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject RDoor;
    public GameObject LDoor;
    public GameObject CircuitBoard;
    public AudioSource errorSound;
    public int failCounter = 0;
    public GameObject player;
    public GameObject robotSpawner;
    public GameObject circuitSpawner;


    // Start is called before the first frame update
    void Start()
    {
        //coroutine for setting up the door to get the right circuit
        StartCoroutine(SetupButton());

        //sets the errorSound to what ever audioSource is attached to this object.
        errorSound = GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");


        //test til at dørene virker
        /* 
        if (CircuitBoard.GetComponent<CircuitScript>().doorpoints == 4)
        {
            StartCoroutine(DoorOpens());
            StartCoroutine(DoorOpens2());
            Debug.Log("R door x: " + RDoor.transform.position.x);
            Debug.Log("R door y: " + RDoor.transform.position.y);
            Debug.Log("R door z: " + RDoor.transform.position.z);

            Debug.Log("L door x: " + LDoor.transform.position.x);
            Debug.Log("L door y: " + LDoor.transform.position.y);
            Debug.Log("L door z: " + LDoor.transform.position.z);
        }
        */
    }

    public void OnTriggerEnter(Collider other)
    {
        //checks if the circuitboard is correct, then starts the couroutines for opening the doors.
        
        if (CircuitBoard.GetComponent<CircuitScript>().doorpoints == CircuitBoard.GetComponent<CircuitScript>().target)
        {
            StartCoroutine(DoorOpens());
            StartCoroutine(DoorOpens2());

        }

        else
        {
            errorSound.Play();

            StartCoroutine(failed());
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

    IEnumerator SetupButton()
    {
        Debug.Log("coroutine started");
        //Wait for 5 seconds so we're sure that everything is instantiated correctly, and we hope no one can solve this within 5 seconds and press the door button.
        yield return new WaitForSeconds(5);

        //sets the circuitboard variable to what ever is spawned in from the spawaner set to this button.
        //CircuitBoard = GameObject.Find(circuitSpawner.GetComponent<Spawner>().circuits[circuitSpawner.GetComponent<Spawner>().s].name + "(Clone)");



        Debug.Log(CircuitBoard.GetComponent<CircuitScript>().target);


    }

    IEnumerator failed()
    {

        robotSpawner.GetComponent<RoboSpawn>().SpawnTheRobo();

        failCounter++;

        yield return new WaitForEndOfFrame();

        if(failCounter >= 5)
        {
            //maybe play a sound of being electrocuted.

            //put in about how long the sound should play before the player drops dead
            //yield return new WaitForSeconds(0.5);

            
            player.GetComponent<Healthsystem>().Death();    


        }


    }
}
