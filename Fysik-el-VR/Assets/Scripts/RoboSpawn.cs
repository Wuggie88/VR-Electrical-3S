using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboSpawn : MonoBehaviour
{
    public GameObject EnemyRobot;

    public int NumberOfSpawn;
    public int AllowedSpawn;

    private void Start()
    {
        //Star koden her med et check
        Invoke("CheckTheSpawn", 1);
    }

    void CheckTheSpawn()
    {
        //check antal spawn ud fra level og base
        if (NumberOfSpawn <= AllowedSpawn)
        {
            Invoke("SpawnTheRobo", 2);
        }
        else
        {
            Invoke("NoMoreBots", 2);
        }

        // se om der er det antal Spwans vi gerne vil have
    }

    void SpawnTheRobo()
    {
        // spawn en enkelt robot og check om vi har nået maks
        Instantiate(EnemyRobot);
    }

    void NoMoreBots()
    {
        //slut spawn indtil næste level
        //start spawn igen
    }
}
