using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3.0f; // The speed at which the enemy moves.
    public Transform[] waypoints;  // An array of waypoints for the enemy to follow.
    private int currentWaypointIndex = 0; // The index of the current waypoint.



    public int health = 30;
    public float playerDetectRange = 5f;
    public Transform player;

    private void Start()
    {
        // Initialize the enemy at the first waypoint.
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }
    public void GetShot(int amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Elim();
        }
    }

    void Elim()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to the enemy.");
            return;
        }
        if (player != null && Vector3.Distance(transform.position, player.position) <= playerDetectRange)
        {
            // Move towards the player.
            Vector3 playerDirection = player.position - transform.position;
            transform.position += playerDirection.normalized * moveSpeed * Time.deltaTime;
            transform.LookAt(player);
        }
        else
        // Move towards the current waypoint.
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            //Rotate to look at next waypoint 
            transform.LookAt(targetPosition);

            // Check if the enemy has reached the current waypoint.
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Move to the next waypoint or loop back to the beginning if at the last waypoint.
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
}
