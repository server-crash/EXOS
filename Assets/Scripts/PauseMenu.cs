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
    public WinScreen winscreen;
    public GameObject winpanelUI;
    public AudioSource winaudio;
    void Start()
    {
        Time.timeScale=1f;
    }
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

        if(winscreen.count==13)
        {
            //win game screen
            winscreen.count=0;
            winaudio.Play(0);
             mouse.enabled=true;
            mouse.CursorUnlock();
            manager.PauseGame();
            winpanelUI.SetActive(true);
            Time.timeScale = 0f;
            manager.IsPaused();
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
        manager.IsPlay();
    }
    void Pause()
    {
        mouse.enabled=true;
        mouse.CursorUnlock();
        manager.PauseGame();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        manager.IsPaused();
    }
    void Pause2()
    {
        mouse.enabled=true;
        mouse.CursorUnlock();
        manager.PauseGame();
        restartMenuUI.SetActive(true);
        Time.timeScale = 0f;
        manager.IsPaused();
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
