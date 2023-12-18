using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingInGame : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void SetVol(float vol)
    {
        audioMixer.SetFloat("MasterVol", vol);
    }
}
