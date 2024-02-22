using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingStones : MonoBehaviour
{
    public int maxHealth = 15;
    public int currentHealth;
    public GameObject stone;
    public GameObject stone1;
    public float destroyDelay = 0.2f;
    public float appearSpeed = 0.2f;

    void Start()
    {

        currentHealth = maxHealth;
        
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Invoke("Destroyed", destroyDelay);
           
        }
    }

    void Destroyed()
    {
        Destroy(gameObject);
        Appear();
    }

    void Appear()
    {

        stone.transform.position += Vector3.up * 3f;
        stone1.transform.position += Vector3.up * 3f;

    }
}
