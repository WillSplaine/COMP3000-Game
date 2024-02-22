using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FellInWater : MonoBehaviour
{

    public GameObject DeathScreen;
    public static bool playerFell;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerFell = true;

          Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
         DeathScreen.SetActive(true);
         Time.timeScale = 0f;
        }
            
        
    }

    
}
