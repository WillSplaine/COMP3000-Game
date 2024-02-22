using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject torch;
    public bool isLit;

    // Update is called once per frame

    private void Start()
    {
        torch.SetActive(false);
        isLit = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !isLit) 
        {
            torch.SetActive(true);
            isLit = true;
        }else 

        if (Input.GetKeyDown(KeyCode.F) && isLit)
        {
            torch.SetActive(false);
            isLit = false;
        }

    }
}
