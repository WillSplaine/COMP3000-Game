using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivate : MonoBehaviour
{
    public bool playerInCollider = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
            }

        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = false;
        }

    }



}


