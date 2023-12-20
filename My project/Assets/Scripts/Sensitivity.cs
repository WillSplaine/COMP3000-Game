using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Sensitivity : MonoBehaviour
{
   
    public Slider sensitivitySliderX;
    public Slider sensitivitySliderY;
    public TextMeshProUGUI sensitivityXText;
    public TextMeshProUGUI sensitivityYText;


    public float sensitivityX = 500f; 
    public float sensitivityY = 500f; 

    void Awake()
    {
        sensitivityX = sensitivitySliderX.value;
        sensitivityY = sensitivitySliderY.value;

        UpdateSensitivityText();
    }

    void Update()
    {
        sensitivityX = 200f * (sensitivitySliderX.value * 0.5f);
        sensitivityY = 200f * (sensitivitySliderY.value * 0.5f);
        UpdateSensitivityText();
    }

    void UpdateSensitivityText()
    {
        sensitivityXText.text = $"Horizontal Sensitivity: {sensitivityX:F1}";
        sensitivityYText.text = $"Vertical Sensitivity: {sensitivityY:F1}";
    }
}


