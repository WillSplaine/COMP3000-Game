using UnityEngine;
using System.Collections;

public class LaserFire : MonoBehaviour
{
    public AudioSource lasershot;
    public ParticleSystem lasermuzzle;
    public BatteryUI batteryUI;

    public Camera Cam;
    public float range = 75f;

    void Start()
    {
        
        lasershot = GetComponent<AudioSource>();
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
        if (batteryUI.currentCharge > 0)
        {
            lasershot.Play();
            lasermuzzle.Play();
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.GetShot(15);
                }
            }
            RaycastHit hittarget;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hittarget, range))
            {
                TargetPracticeMini target = hittarget.transform.GetComponent<TargetPracticeMini>();
                if (target != null)
                {
                    target.takeDamage(15);
                }
            }



        }
    }
}
