using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsFX : MonoBehaviour
{

    public AudioSource footstepFX;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.A))))){
            footstepFX.enabled = true; 
        }
        else { 
            footstepFX.enabled = false; }

    }
}
