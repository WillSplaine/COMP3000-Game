using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public LayerMask wallLayer;
    public float maxGrabTime = 5f;
    public float grabSpeed = 2f;

    private bool isGrabbing = false;
    private float currentGrabTime = 0f;
    private Vector3 wallNormal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGrabbing)
        {
            TryGrabWall();
        }

        if (isGrabbing)
        {
            WallTraversal();
        }
    }

    void TryGrabWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, wallLayer))
        {
            isGrabbing = true;
            currentGrabTime = 0f;
            wallNormal = hit.normal;
        }
    }

    void WallTraversal()
    {
        currentGrabTime += Time.deltaTime;

        if (currentGrabTime >= maxGrabTime)
        {
            ReleaseWall();
            return;
        }

        // Move the player towards the ground along the wall
        transform.position += wallNormal * grabSpeed * Time.deltaTime;

        // Perform any additional traversal logic here

        // Release the wall if necessary (e.g., a button press)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReleaseWall();
        }
    }

    void ReleaseWall()
    {
        isGrabbing = false;
    }
}

