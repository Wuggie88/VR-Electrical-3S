using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthsystem : MonoBehaviour
{
    public int health = 100;

    public int SP;

    public GameObject Healthdrop;

    public int heal = 10;

    // Start is called before the first frame update
    void Start()
    {
        SP = GetComponent<RoboSpawn>().NumberOfSpawn;

    }

    private void Update()
    {
        if (health <= 0) Death();
    }

    public void HealThePlayer(int heal)
    {
        health += heal;
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
            Instantiate(Healthdrop, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        
    }
}
