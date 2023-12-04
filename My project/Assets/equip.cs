using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equip : MonoBehaviour
{
    public GameObject object1; 
    public GameObject object2; 

    private bool isInsideCollider = false;

    void Update()
    {
        if (isInsideCollider && Input.GetKeyDown(KeyCode.E))
        {
            
            ToggleVisibility(object1);
            ToggleVisibility(object2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the collider is triggered by the "Player" tag
        {
            isInsideCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideCollider = false;
        }
    }

    private void ToggleVisibility(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
}


