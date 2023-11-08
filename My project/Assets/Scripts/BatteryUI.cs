using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Image[] healthSegments = new Image[10];

    private void Start()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        int segmentSize = maxHealth / healthSegments.Length;

        for (int i = 0; i < healthSegments.Length; i++)
        {
            if (currentHealth >= (i + 1) * segmentSize)
            {
                healthSegments[i].enabled = true;
            }
            else
            {
                healthSegments[i].enabled = false;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            GainHealth(10);
        }
        if (Input.GetKeyDown("i"))
        {
            LoseHealth(10);
        }
    }

    public void GainHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateHealthBar();
    }

    public void LoseHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        UpdateHealthBar();
    }
}
