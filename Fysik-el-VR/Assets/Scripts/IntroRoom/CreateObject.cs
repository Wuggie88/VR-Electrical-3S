using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour
{
    public Transform BattteriSpawnpoint;
    public Transform ResistorSpawnPoint;

    public Rigidbody BatteriPrefab;
    public Rigidbody ResistorPrefab;

    public bool BatteriIsspawned = false;
    public bool ResistorIsSpawn = false;

    void OnTriggerEnter ()
    {

        if (!BatteriIsspawned)
        {
            Rigidbody batPrefab;
            batPrefab = Instantiate(BatteriPrefab, BattteriSpawnpoint.position, BattteriSpawnpoint.rotation) as Rigidbody;
            BatteriIsspawned = true;
        } else if (!ResistorIsSpawn)
        {
            Rigidbody resPrefab;
            resPrefab = Instantiate(ResistorPrefab, ResistorSpawnPoint.position, ResistorSpawnPoint.rotation) as Rigidbody;
            ResistorIsSpawn = true;
        }        
    }
}
