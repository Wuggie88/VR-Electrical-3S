using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemAdd : MonoBehaviour
{
    int AddingHealth = 10;
    private int DeSpawnTime = 2;
    private OVRGrabbable ovrGrabbable;
    GameObject player;

    


    // Start is called before the first frame update
    void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrGrabbable.isGrabbed)
        {
            Heal();
        }

    }

    void DestroyTheHI()
    {
        Destroy(this.gameObject);
    }

    void Heal()
    {
        player.GetComponent<Healthsystem>().HealThePlayer(AddingHealth);
        Invoke("DestroyTheHI", 1);
    }
}

