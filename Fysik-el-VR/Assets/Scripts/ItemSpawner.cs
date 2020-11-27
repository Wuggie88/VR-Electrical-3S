using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject item;
    public GameObject inventorySlot;

    // Start is called before the first frame update
    void Start()
    {   

        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {
        if (item.transform.position != inventorySlot.transform.position)
        {
            SpawnItem();
        }
    }

    public void SpawnItem()
    {
        Instantiate(item, inventorySlot.transform.position, Quaternion.identity);
        return;
    }
    
    

    

  

}
