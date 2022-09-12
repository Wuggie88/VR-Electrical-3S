using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemAdd : MonoBehaviour
{
    int AddingHealth = 10;
    private int DeSpawnTime = 1;
    private OVRGrabbable ovrGrabbable;
    GameObject player;
    bool hasGrabbed = false;
    


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
            if (hasGrabbed == false)
            {
                hasGrabbed = true;
                Invoke("Heal", DeSpawnTime);
            } 
        }
    }

    void DestroyTheHI()
    {
        Destroy(this.gameObject);
    }

    void Heal()
    {
        player.GetComponent<Healthsystem>().HealThePlayer(AddingHealth);
        DestroyTheHI();
        hasGrabbed = false;
    }
}

