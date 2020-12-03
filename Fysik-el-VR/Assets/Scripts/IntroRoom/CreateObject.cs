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

    public Rigidbody BatteriPrefab;
    public Rigidbody ResistorPrefab;
    public Dialogue dialogue;

    private bool BatteriIsspawned = false;
    private bool ResistorIsSpawn = false;

    void Start()
    {
        BHint = GameObject.Find("BatteriHint");
        BHint.gameObject.SetActive(false);

        RHint = GameObject.Find("ResistorHint");
        RHint.gameObject.SetActive(false);

        DHint = GameObject.Find("DoorOpenerHint");
        DHint.gameObject.SetActive(false);
    }

    void OnTriggerEnter ()
    {

        if (!BatteriIsspawned)
        {

            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            BHint.gameObject.SetActive(true);
            Rigidbody batPrefab;
            batPrefab = Instantiate(BatteriPrefab, BattteriSpawnpoint.position, BattteriSpawnpoint.rotation) as Rigidbody;
            BatteriIsspawned = true;

        } else if (!ResistorIsSpawn)
        {
            BHint.gameObject.SetActive(false);
            RHint.gameObject.SetActive(true);
            Rigidbody resPrefab;
            resPrefab = Instantiate(ResistorPrefab, ResistorSpawnPoint.position, ResistorSpawnPoint.rotation) as Rigidbody;
            ResistorIsSpawn = true;
        }
        else {
            RHint.gameObject.SetActive(false);
            DHint.gameObject.SetActive(true);
        }
    }
}
