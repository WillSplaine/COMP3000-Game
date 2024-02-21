using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pickUpPrompt : MonoBehaviour
{
    public TextMeshProUGUI pickupPrompt;
    public bool playerInCollider = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = true;
            pickupPrompt.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = false;
            pickupPrompt.gameObject.SetActive(false);
        }
    }



}
