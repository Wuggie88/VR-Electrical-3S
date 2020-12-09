using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboSpawn : MonoBehaviour
{
    public GameObject EnemyRobot;
    public GameObject Spawnpoint;

    public int NumberOfSpawn;
    public int AllowedSpawn;

    public bool fail = false;


    private void Start()
    {
        //Star koden her med et check
        Invoke("CheckTheSpawn", 1);
    }

   /* private void Update()
    {
        if(NumberOfSpawn == 0 && fail == true)
        {
            Invoke
        }
    }*/

    void CheckTheSpawn()
    {
        //check antal spawn ud fra level og base
        if (NumberOfSpawn < AllowedSpawn)
        {

            Invoke("SpawnTheRobo", 2);
        }
        else
        {
            Invoke("NoMoreBots", 2);
        }

        // se om der er det antal Spwans vi gerne vil have
    }

    public void SpawnTheRobo()
    {
        // spawn en enkelt robot og check om vi har nået maks
        Instantiate(EnemyRobot, Spawnpoint.transform.position, Spawnpoint.transform.rotation);
        NumberOfSpawn++;

        Invoke("CheckTheSpawn", 2);

    }

    public void SpawnFailedRobo()
    {
        StartCoroutine(SpawnFailedRobots());   
    }

    public IEnumerator SpawnFailedRobots()
    {
        for (int i = 0; i<5; i++)
        {
            Instantiate(EnemyRobot, Spawnpoint.transform.position, Spawnpoint.transform.rotation);
            yield return new WaitForSeconds(1);
        }  
    }


    void NoMoreBots()
    {
        if (fail == true)
        {
            fail = false;
            Invoke("CheckTheSpawn", 2);
        }
        else
        {
            Invoke("NoMoreBots", 2);
        }
        //slut spawn indtil næste level
        //start spawn igen
    }

   public void DecreaseNum()
   {
        NumberOfSpawn--;
   }
}
