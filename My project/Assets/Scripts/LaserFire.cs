using UnityEngine;
using System.Collections;

public class LaserFire : MonoBehaviour
{

    public ParticleSystem lasermuzzle;
    public BatteryUI batteryUI;

    public Camera Cam;
    public float range = 75f;

    void Start()
    {
        // Initialize the Trail Renderer component.
        
        BatteryUI batteryUI = GetComponent<BatteryUI>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
          batteryUI.LoseCharge(2);
        }
    }

    void Shoot()
    {
        lasermuzzle.Play();
        RaycastHit hit;
        if(Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetShot(15);
            }
        }


       
        
    }
}
