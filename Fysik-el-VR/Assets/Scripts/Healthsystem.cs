using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Healthsystem : MonoBehaviour
{
    public float health = 100;

    RoboSpawn spawner;

    public GameObject Healthdrop;

    public float heal;
    public Image healthbar;
    public GameObject filler;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<RoboSpawn>();
        UpdateHealthBar();
    }

    private void Update()
    {
        if (health <= 0) Death();
    }

    public void HealThePlayer(int heal)
    {
        health += heal;
        if (health > 100) health = 100;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {

        health -= damage;
        UpdateHealthBar();

        if (health <= 0)     Death(); 

    }

    public void Death()
    {
        if (this.tag == "Player")
        {
            filler.SetActive(true);

            Invoke("Restart", 3);
            
            

            //else another solution that might be slower however:
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("første");
            spawner.GetComponent<RoboSpawn>().DecreaseNum();
            Debug.Log("anden");
            Instantiate(Healthdrop, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateHealthBar()
    {
        healthbar.fillAmount = health/100;
    }
}
