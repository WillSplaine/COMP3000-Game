using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayTutorial()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Tutorial Level");
        

    }
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 3");

    }
    public void PlayLevel2()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 2");

    }
}
