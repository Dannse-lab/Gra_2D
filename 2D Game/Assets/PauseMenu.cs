using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Sprawdza,czy gra jest zatrzymana czy nie, jak nie jest zatrzymana, to toczy siê gra, jak jest zatrzymana, to gra siê zatrzymuje
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    // Wznów grê
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    // Zatrzymaj grê
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    // Otwórz menu g³ówne z ekranu pauzy
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    // Zamknij grê
    public void QuitGame()
    {
        Debug.Log("Quitting game ...");
        Application.Quit();
    }
}
