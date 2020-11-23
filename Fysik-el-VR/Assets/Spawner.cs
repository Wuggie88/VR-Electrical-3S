using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public int s = 0;


    // Start is called before the first frame update
    void Start()
    {
        s = Random.Range(0, 4);

        GameObject Circuit = Instantiate(prefabs[s], transform.position, transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
