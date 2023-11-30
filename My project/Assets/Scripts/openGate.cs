using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGate : MonoBehaviour
{

    public GameObject door1;
    public GameObject door2;

    private bool doorsOpen = false;

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoors();
        }
    }

    private void ToggleDoors()
    {
      
        doorsOpen = !doorsOpen;

     
        if (doorsOpen)
        {
            OpenDoors();
        }
        else
        {
            CloseDoors();
        }
    }

    private void OpenDoors()
    {
       
 
        door1.transform.Translate(Vector3.left * 4f);
        door2.transform.Translate(Vector3.right * 4f);
    }

    private void CloseDoors()
    {
 
        door1.transform.Translate(Vector3.right * 4f);
        door2.transform.Translate(Vector3.left * 4f);
    }
}




