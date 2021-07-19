using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameManager manager;
    public MouseLook mouse;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                //mouse.enabled=false;
                //mouse.CursorLock();
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        mouse.enabled=false;
        mouse.CursorLock();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        manager.ResumeGame();
    }
    void Pause()
    {
        mouse.enabled=true;
        mouse.CursorUnlock();
        manager.PauseGame();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
