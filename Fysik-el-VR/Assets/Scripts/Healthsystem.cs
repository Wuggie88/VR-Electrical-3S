using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthsystem : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
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
            //hvis en dødsscene
        }
        else
        {
            Destroy(this);
        }
        
    }
}
