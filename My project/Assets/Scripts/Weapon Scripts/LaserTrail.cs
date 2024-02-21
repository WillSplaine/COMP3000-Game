using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrail : MonoBehaviour
{
    public TrailRenderer trailPrefab;
    public Transform gunTransform;

    public float bulletSpeed = 10f; // Adjust as needed

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Change this condition based on your input method
        {
            ShootTrail();
        }
    }

    void ShootTrail()
    {
        TrailRenderer trail = Instantiate(trailPrefab, gunTransform.position, gunTransform.rotation);
        trail.transform.forward = gunTransform.forward; // Set the trail's direction.

        // Set any additional properties of the trail here, e.g., trail time, width, etc.

        Destroy(trail.gameObject, trail.time); // Destroy the trail after its duration.

        // If you want the trail to interact with the environment, you can add collision logic here.
        // Example:
        // void OnCollisionEnter(Collision collision)
        // {
        //     // Handle collision logic if needed.
        //     Destroy(gameObject); // Destroy the trail on collision.
        // }
    }
}
