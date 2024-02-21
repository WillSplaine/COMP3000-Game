using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial Level");

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 3");

    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("Game");

    }
}
