using UnityEngine;
using System.Collections;

public class LaserFire : MonoBehaviour
{
    public Transform weaponTransform; // The transform of your weapon.
    public LayerMask targetLayer; // The layer(s) to detect the target.
    public TrailRenderer trailRenderer; // Trail Renderer component to visualize the laser trail.

    public float trailStartDistance = 0.5f; // Distance from the gun tip to start the trail.
    public float trailMaxLength = 10f; // Maximum length of the trail.

    void Start()
    {
        // Initialize the Trail Renderer component.
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(weaponTransform.position + weaponTransform.forward * trailStartDistance, weaponTransform.forward);
        RaycastHit hit;

        trailRenderer.Clear();
        trailRenderer.enabled = true;
        trailRenderer.AddPosition(ray.origin);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
        {
            // You hit something on the target layer. You can handle the hit here.
            Vector3 endPoint = ray.GetPoint(Vector3.Distance(ray.origin, hit.point));
            trailRenderer.AddPosition(endPoint);

            // You can perform additional actions, such as damaging the target, here.
        }
        else
        {
            // The ray did not hit anything on the target layer.
            Vector3 endPoint = ray.GetPoint(trailMaxLength); // Extend the line to the maximum length.
            trailRenderer.AddPosition(endPoint);
        }

        // Disable the Trail Renderer after the laser has been fired.
        StartCoroutine(DisableTrail());
    }

    IEnumerator DisableTrail()
    {
        // Wait for a longer duration and then disable the Trail Renderer.
        yield return new WaitForSeconds(0.5f); // Adjust the duration as needed.
        trailRenderer.enabled = false;
    }
}
