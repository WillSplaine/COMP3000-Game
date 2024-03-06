using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 3.0f; // The speed at which the platform moves.
    public float stopDuration = 3.0f; // The duration to stop at each waypoint.
    public Transform[] waypoints;  // An array of waypoints for the platform to follow.
    private int currentWaypointIndex = 0; // The index of the current waypoint.
    private bool isMoving = true; // Flag to track whether the platform is currently moving or stopped.
    private Transform player; // Reference to the player.

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player GameObject and get its transform.
        StartCoroutine(MoveBetweenWaypoints());
    }

    IEnumerator MoveBetweenWaypoints()
    {
        while (true)
        {
            // Move towards the current waypoint.
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the platform has reached the current waypoint.
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Stop at the waypoint for the specified duration.
                yield return new WaitForSeconds(stopDuration);

                // Move to the next waypoint or reverse direction if at the last or first waypoint.
                if (currentWaypointIndex == waypoints.Length - 1)
                {
                    currentWaypointIndex = 0;
                }
                else
                {
                    currentWaypointIndex++;
                }
            }

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isMoving)
        {
            player.parent = transform; // Make the player a child of the platform.
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isMoving)
        {
            player.parent = null; // Release the player from being a child of the platform.
        }
    }

   
}
