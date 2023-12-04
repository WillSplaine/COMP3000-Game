using UnityEngine;

public class uiState : MonoBehaviour
{
    // Reference to the UI elements related to the gun
    public GameObject gun;
    public GameObject batt;
    public GameObject cC;
    public GameObject tip;
    // Add more UI elements as needed

    void OnTriggerEnter(Collider other)
    {
        // Check if the player picks up the gun (you can customize the condition as needed)
        if (gun.activeSelf == true)
        {
            // Activate the UI elements related to the gun
            ActivateGunUI();
        }
    }

    void ActivateGunUI()
    {
        if (batt != null && !batt.activeSelf)
        {
            batt.SetActive(true);
        }

        if (cC != null && !cC.activeSelf)
        {
            cC.SetActive(true);
        }

        if (tip != null && !tip.activeSelf)
        {
            tip.SetActive(true);
        }

        // Add more UI activation as needed
    }
}
