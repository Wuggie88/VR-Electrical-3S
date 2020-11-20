using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektileEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxLifeTime = 2f;


    public int damage;


    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, MaxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<Healthsystem>().TakeDamage(damage);

        }


    }
}
