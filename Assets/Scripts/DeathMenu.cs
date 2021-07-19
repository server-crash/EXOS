using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameManager manager;
    public MouseLook mouse;
    public HealthManager health;
    void Update()
    {
        if(health.currentHealth<=0f)
        {
            Pause();
        }
    }
    void Pause()
    {
        mouse.enabled=true;
        mouse.CursorUnlock();
        manager.PauseGame();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        mouse.enabled=false;
        mouse.CursorLock();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        manager.ResumeGame();
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
    public void restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

