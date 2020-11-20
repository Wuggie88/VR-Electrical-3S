using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektile : MonoBehaviour
{
    public float MaxLifeTime = 2f;

    public int damage;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, MaxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.gameObject.GetComponent<Healthsystem>().TakeDamage(damage);

        }


    }

}


