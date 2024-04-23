using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialVoiceover : MonoBehaviour
{
    public AudioClip soundClip; // Sound clip to play
    private AudioSource audioSource; // Reference to AudioSource component

    void Start()
    {
        // Get reference to AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource component exists, if not, add it
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the sound clip to the AudioSource
        audioSource.clip = soundClip;
    }

    // This function is called when another collider enters the trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Play the sound clip
            audioSource.Play();
        }
    }
}
