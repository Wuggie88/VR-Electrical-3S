using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject item;
    public GameObject inventorySlot;
    public bool state = true;


    // Start is called before the first frame update
    void Start()
    {

        SpawnItem();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnItem()
    {
        Instantiate(item, inventorySlot.transform.position, Quaternion.identity);

        return;

    }
    void OnTriggerExit(Collider other)
    {

        StartCoroutine(SpawnDelay());

    }
    
    IEnumerator SpawnDelay()
    {
        if (state == true)
        {
            SpawnItem();
            state = false;
            yield return new WaitForSeconds(2);
            state = true;
        }


    }




}
