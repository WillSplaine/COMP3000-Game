using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    public int maxCharge = 100;
    public int currentCharge = 100;
    public Image[] chargeSegments = new Image[10];
    public GrapplingGun Grappling;


    private void Start()
    {
        UpdateChargeBar();
    }

    private void UpdateChargeBar()
    {
        int segmentSize = maxCharge / chargeSegments.Length;

        for (int i = 0; i < chargeSegments.Length; i++)
        {
            if (currentCharge >= (i + 1) * segmentSize)
            {
                chargeSegments[i].enabled = true;
            }
            else
            {
                chargeSegments[i].enabled = false;
            }
        }
    }

    private void Update()
    {
       
       // if (Input.GetKeyDown(KeyCode.Mouse1))
        {
          //  LoseHealth(3);
        }
        
    }

    public void GainCharge(int amount)
    {
        currentCharge = Mathf.Clamp(currentCharge + amount, 0, maxCharge);
        UpdateChargeBar();
    }

    public void LoseCharge(int amount)
    {
        currentCharge = Mathf.Clamp(currentCharge - amount, 0, maxCharge);
        UpdateChargeBar();
    }
}
