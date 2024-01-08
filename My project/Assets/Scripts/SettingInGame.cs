using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingInGame : MonoBehaviour
{
    
    public AudioMixer audioMixerMus;
    public AudioMixer audioMixerSFX;

  
    public void SetVolMus(float vol)
    {
        audioMixerMus.SetFloat("MusVol", vol);
    }
    

    public void SetVolSFX(float vol)
    {
        audioMixerSFX.SetFloat("SFXVol", vol);
    }
}
