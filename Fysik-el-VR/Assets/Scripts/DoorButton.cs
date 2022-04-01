using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject RDoor;
    public GameObject LDoor;
    public GameObject CircuitBoard;
    public GameObject CircuitBoard2;
    public AudioSource errorSound;
    public int failCounter = 0;
    public GameObject player;
    public GameObject robotSpawner;
    public GameObject circuitSpawner;
    public GameObject circuitSpawner2;
    public GameObject IndLight;
    public GameObject IndLight2;
    Color redGlow;
    Color greenGlow;


    // Start is called before the first frame update
    void Start()
    {
        //coroutine for setting up the door to get the right circuit
        StartCoroutine(SetupButton());

        //sets the errorSound to what ever audioSource is attached to this object.
        errorSound = GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");
        ColorUtility.TryParseHtmlString("#FF0000", out redGlow);
        ColorUtility.TryParseHtmlString("#00FF00", out greenGlow);

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

        if (CircuitBoard.GetComponent<CircuitScript>().doorpoints == CircuitBoard.GetComponent<CircuitScript>().target &&
            CircuitBoard2.GetComponent<CircuitScript>().doorpoints == CircuitBoard2.GetComponent<CircuitScript>().target)
        {

            GameObject IndLightDispers = IndLight.transform.Find("Spotlight").gameObject;
            IndLightDispers.GetComponent<Light>().color = Color.red;

            GameObject LightMat1 = IndLight.transform.Find("Light_01").gameObject;
            Material Light1 = LightMat1.GetComponent<Renderer>().material;
            Light1.SetColor("_EmissionColor", greenGlow);
            Light1.SetColor("_Color", greenGlow);

            GameObject IndLight2Dispers = IndLight2.transform.Find("Spotlight").gameObject;
            IndLight2Dispers.GetComponent<Light>().color = Color.green;

            GameObject LightMat2 = IndLight2.transform.Find("Light_01").gameObject;
            Material Light2 = LightMat2.GetComponent<Renderer>().material;
            Light2.SetColor("_EmissionColor", greenGlow);
            Light2.SetColor("_Color", greenGlow);
            StartCoroutine(DoorOpens());
            StartCoroutine(DoorOpens2());

        }else if(CircuitBoard.GetComponent<CircuitScript>().doorpoints == CircuitBoard.GetComponent<CircuitScript>().target &&
            CircuitBoard2.GetComponent<CircuitScript>().doorpoints != CircuitBoard2.GetComponent<CircuitScript>().target)
        {
            errorSound.Play();


            GameObject IndLightDispers = IndLight.transform.Find("Spotlight").gameObject;
            IndLightDispers.GetComponent<Light>().color = Color.red;

            GameObject LightMat1 = IndLight.transform.Find("Light_01").gameObject;
            Material Light1 = LightMat1.GetComponent<Renderer>().material;
            Light1.SetColor("_EmissionColor", greenGlow);
            Light1.SetColor("_Color", greenGlow);

            GameObject IndLight2Dispers = IndLight2.transform.Find("Spotlight").gameObject;
            IndLight2Dispers.GetComponent<Light>().color = Color.green;

            GameObject LightMat2 = IndLight2.transform.Find("Light_01").gameObject;
            Material Light2 = LightMat2.GetComponent<Renderer>().material;
            Light2.SetColor("_EmissionColor", redGlow);
            Light2.SetColor("_Color", redGlow);


            StartCoroutine(failed());

        }else if (CircuitBoard.GetComponent<CircuitScript>().doorpoints != CircuitBoard.GetComponent<CircuitScript>().target &&
            CircuitBoard2.GetComponent<CircuitScript>().doorpoints == CircuitBoard2.GetComponent<CircuitScript>().target)
        {
            errorSound.Play();

            GameObject IndLightDispers = IndLight.transform.Find("Spotlight").gameObject;
            IndLightDispers.GetComponent<Light>().color = Color.red;

            GameObject LightMat1 = IndLight.transform.Find("Light_01").gameObject;
            Material Light1 = LightMat1.GetComponent<Renderer>().material;
            Light1.SetColor("_EmissionColor", redGlow);
            Light1.SetColor("_Color", redGlow);

            GameObject IndLight2Dispers = IndLight2.transform.Find("Spotlight").gameObject;
            IndLight2Dispers.GetComponent<Light>().color = Color.green;

            GameObject LightMat2 = IndLight2.transform.Find("Light_01").gameObject;
            Material Light2 = LightMat2.GetComponent<Renderer>().material;
            Light2.SetColor("_EmissionColor", greenGlow);
            Light2.SetColor("_Color", greenGlow);

            StartCoroutine(failed());

        }

        //if all is incorrect
        else
        {

            GameObject IndLightDispers = IndLight.transform.Find("Spotlight").gameObject;
            IndLightDispers.GetComponent<Light>().color = Color.red;

            GameObject LightMat1 = IndLight.transform.Find("Light_01").gameObject;
            Material Light1 = LightMat1.GetComponent<Renderer>().material;
            Light1.SetColor("_EmissionColor", redGlow);
            Light1.SetColor("_Color", redGlow);

            GameObject IndLight2Dispers = IndLight2.transform.Find("Spotlight").gameObject;
            IndLight2Dispers.GetComponent<Light>().color = Color.green;

            GameObject LightMat2 = IndLight2.transform.Find("Light_01").gameObject;
            Material Light2 = LightMat2.GetComponent<Renderer>().material;
            Light2.SetColor("_EmissionColor", redGlow);
            Light2.SetColor("_Color", redGlow);
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
        //Wait for 5 seconds so we're sure that everything is instantiated correctly, and we hope no one can solve this within 5 seconds and press the door button.
        yield return new WaitForSeconds(5);

        //sets the circuitboard variable to what ever is spawned in from the spawaner set to this button.
        CircuitBoard = GameObject.Find(circuitSpawner.GetComponent<Spawner>().circuits[circuitSpawner.GetComponent<Spawner>().s].name + "(Clone)");
        CircuitBoard2 = GameObject.Find(circuitSpawner2.GetComponent<Spawner>().circuits[circuitSpawner2.GetComponent<Spawner>().s].name + "(Clone)");
    }

    IEnumerator failed()
    {
        //calls the method that stars the coroutine for spawning new robots on fail
        robotSpawner.GetComponent<RoboSpawn>().SpawnFailedRobo();
        //adds 1 point to the fail counter
        failCounter++;

        yield return new WaitForEndOfFrame();
        //checks if the fail counter is equal to or higher than 5, if it is. it will trigger the death on the player.
        if(failCounter >= 5)
        {           
            player.GetComponent<Healthsystem>().Death();    
        }
    }
}
