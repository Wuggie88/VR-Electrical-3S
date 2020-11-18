using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthsystem : MonoBehaviour
{
    
    public int health;
    public int damage;

    public Collider FjendtligSkud;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other == FjendtligSkud)
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
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
