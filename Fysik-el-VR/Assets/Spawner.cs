using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //makes an empty prefabs list
    public GameObject[] circuits;
    public int s = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnCircuit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCircuit()
    {
        //Picks a random number within the range of the prefabs list.
        s = Random.Range(0, circuits.Length);

        //instantiates the prefab picked by the random number generator "s"
        GameObject Circuit = Instantiate(circuits[s], transform.position, transform.rotation);
    }
    
    
}
