using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthsystem : MonoBehaviour
{
    public int health = 100;

    public int SP;

    // Start is called before the first frame update
    void Start()
    {
        SP = GetComponent<RoboSpawn>().NumberOfSpawn;
    }

    public void TakeDamage(int damage)
    {

        health -= damage;


        if (health <= 0)     Death(); 

    }

    public void Death()
    {
        if (this.tag == "Player")
        {
            //vis en dødsscene
        }
        else
        {
            SP--;
            Destroy(this);
        }
        
    }
}
