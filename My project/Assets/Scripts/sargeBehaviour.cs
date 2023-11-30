using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sargeBehaviour : MonoBehaviour
{
  
    public Transform player; // Drag and drops the player's transform 
    void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the model to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Use LookRotation to rotate the model to face the player
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate the model towards the player over time
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}


