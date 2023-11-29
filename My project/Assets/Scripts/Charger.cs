using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    BatteryUI batt;

    void Awake()
    {
        batt = FindObjectOfType<BatteryUI>();
    }

            public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                batt.GainCharge(5);
            }
        }




}

