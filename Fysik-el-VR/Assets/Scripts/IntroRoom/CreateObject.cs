using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour
{
    public Transform BattteriSpawnpoint;
    public Transform ResistorSpawnPoint;


    private GameObject BHint;
    private GameObject RHint;
    private GameObject DHint;
    public GameObject tHint;

    public Rigidbody BatteriPrefab;
    public Rigidbody ResistorPrefab;

    bool hintTextShown = false;
    public Dialogue dialogue;

    private bool BatteriIsspawned = false;
    private bool ResistorIsSpawn = false;

    void Start()
    {
        //Finds the object and deactivating the hints//
        BHint = GameObject.Find("BatteriHint");
        BHint.gameObject.SetActive(false);

        RHint = GameObject.Find("ResistorHint");
        RHint.gameObject.SetActive(false);

        DHint = GameObject.Find("DoorOpenerHint");
        DHint.gameObject.SetActive(false);
    }

    public void OnTriggerEnter (Collider other)
    {
        //Starting the dialog//
        if (hintTextShown == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            hintTextShown = true;
        }

        if (!BatteriIsspawned)
        {
            //Activate the hint & Spawning the batteri//
            BHint.gameObject.SetActive(true);
            Rigidbody batPrefab;
            batPrefab = Instantiate(BatteriPrefab, BattteriSpawnpoint.position, BattteriSpawnpoint.rotation) as Rigidbody;
            BatteriIsspawned = true;
            tHint.gameObject.SetActive(false);

        } else if (!ResistorIsSpawn)
        {
            //Activate the hint & Spawning the risistor//
            RHint.gameObject.SetActive(true);
            Rigidbody resPrefab;
            resPrefab = Instantiate(ResistorPrefab, ResistorSpawnPoint.position, ResistorSpawnPoint.rotation) as Rigidbody;
            ResistorIsSpawn = true;
        }
        else {

            //Activate the door hint//
            DHint.gameObject.SetActive(true);
            tHint.gameObject.SetActive(false);
        }
    }
}
