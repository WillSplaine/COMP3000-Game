using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTimer : MonoBehaviour
{
    public GameObject finalScoreScreen;
    public static bool runComplete;
    public float FinishCelebrationDelay = 1.0f;
    public TMP_Text source;
    public TMP_Text finishScreen;
    public GameObject Timer;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        EventManager.OnTimerEnd();
        ShowTime();
        runComplete = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        finalScoreScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    void ShowTime()
    {
     finishScreen.text = "Your Finished time  " + source.text;
        Timer.SetActive(false);
    }

    
}
