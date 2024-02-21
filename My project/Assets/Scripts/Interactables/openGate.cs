using System.Collections;
using UnityEngine;
using TMPro;

public class openGate : MonoBehaviour
{
    public Animator levAnim;
    public GameObject door1;
    public GameObject door2;
    public TextMeshProUGUI interactPrompt; 
    public float doorMoveDistance = 4f;
    public float doorOpenCloseDuration = 1f;

    private bool doorsOpen = false;
    private bool playerInCollider = false;


    private void Start()
    {
        levAnim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = true;
            interactPrompt.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = false;
            interactPrompt.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the player is in the collider and pressing E
        if (Input.GetKeyDown(KeyCode.E) && playerInCollider)
        {
            ToggleDoors();
        }
    }

    private void ToggleDoors()
    {
        doorsOpen = !doorsOpen;

        if (doorsOpen)
        {
            levAnim.SetTrigger("Pull");
            StartCoroutine(MoveDoors(door1, Vector3.left, doorMoveDistance, doorOpenCloseDuration));
            StartCoroutine(MoveDoors(door2, Vector3.right, doorMoveDistance, doorOpenCloseDuration));
        }
        else
        {
            levAnim.SetTrigger("Push");
            
            StartCoroutine(MoveDoors(door1, Vector3.right, doorMoveDistance, doorOpenCloseDuration));
            StartCoroutine(MoveDoors(door2, Vector3.left, doorMoveDistance, doorOpenCloseDuration));
        }
    }

    private IEnumerator MoveDoors(GameObject door, Vector3 direction, float distance, float duration)
    {
        Vector3 initialPosition = door.transform.position;
        Vector3 targetPosition = initialPosition + direction * distance;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            door.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure door reaches the exact target position to avoid floating point errors
        door.transform.position = targetPosition;
    }
}
