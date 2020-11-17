using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektile : MonoBehaviour
{
    public LayerMask Player;
    public float MaxLifeTime = 2f;


    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, MaxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Player);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
