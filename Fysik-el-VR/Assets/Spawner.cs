using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //makes an empty prefabs list
    public GameObject[] circuits;
    public int s = 0;
    public string circuitPicked;
    

    // Start is called before the first frame update
    void Start()
    {
        //Picks a random number within the range of the prefabs list.
        s = Random.Range(0, circuits.Length);

        //instantiates the prefab picked by the random number generator "s"
        //GameObject Circuit = Instantiate(prefabs[s], transform.position, transform.rotation);
        GameObject Circuit = Instantiate(circuits[s], transform.position, transform.rotation);

        string circuitString = circuits[s].ToString();

        string[] split = circuitString.Split(' ');

        Debug.Log("circuit picked: " + circuitString.Equals(split[0].ToString()));

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
