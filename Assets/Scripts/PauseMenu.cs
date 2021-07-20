using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject restartMenuUI;
    public GameManager manager;
    public MouseLook mouse;
    public HealthManager health;
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
        if(health.currentHealth<=0f)
        {
            Pause2();
        }
    }
    public void Resume()
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
    void Pause2()
    {
        mouse.enabled=true;
        mouse.CursorUnlock();
        manager.PauseGame();
        restartMenuUI.SetActive(true);
        Time.timeScale = 0f;
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
    public void Restart()
    {
        //Resume();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
