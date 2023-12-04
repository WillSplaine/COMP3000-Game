using UnityEngine;

public class Hide : MonoBehaviour
{
    public float interactionRange = 2f;
    public LayerMask interactableLayer;
    public GameObject replacementObjectPrefab; // Assign the prefab in the inspector

    private void Update()
    {
        // Check for user input (E key)
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Perform raycasting
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
            {
                // Check if the object has the necessary components
                GameObject interactedObject = hit.transform.gameObject;

                // Hide the object
                Renderer renderer = interactedObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.enabled = false;

                    // Instantiate a replacement object if provided
                    if (replacementObjectPrefab != null)
                    {
                        Instantiate(replacementObjectPrefab, interactedObject.transform.position, interactedObject.transform.rotation);
                    }
                }
            }
        }
    }
}
