using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPracticeMini : MonoBehaviour
{
    public int maxHealth = 15;
    public int currentHealth;
    public Transform[] respawnPositions;
    public int respawnLimit = 10;

    private int respawnCount = 0;

    void Start()
    {
       
        currentHealth = maxHealth;
        Respawn();
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
           
         StartCoroutine(RespawnDelay());
        }
    }

    void Destroyed()
    {
        Destroy(gameObject);
    }
    void Respawn()
    {
        if (respawnCount < respawnLimit)
        {
            int randomIndex = Random.Range(0, respawnPositions.Length);
            transform.position = respawnPositions[randomIndex].position;
            gameObject.SetActive(true);
        }
        else
        {
           
            Debug.Log("Tutorial ended!");
        }
    }


    IEnumerator RespawnDelay()
    {
      yield return new WaitForSeconds(.2f);
        gameObject.SetActive(false);
        respawnCount++;
        Respawn();
    }
}

