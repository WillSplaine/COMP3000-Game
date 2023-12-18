using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public static bool gamePaused;
    // Start is called before the first frame update
    void Start()
    {

        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()

    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SettingsPage()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void SettingsPageReturn()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SetFullscreen (bool Fullscreened)
    {
        Screen.fullScreen = Fullscreened;
    }

}


