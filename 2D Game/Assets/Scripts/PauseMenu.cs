using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    [HideInInspector] public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject summary;

    // Sprawdza,czy gra jest zatrzymana czy nie, jak nie jest zatrzymana, to toczy siê gra, jak jest zatrzymana, to gra siê zatrzymuje
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape) && !summary.activeSelf)
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
        Cursor.visible = false; // Cursor disabled
    }
    // Zatrzymaj grê
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true; // Cursor enabled
    }
    // Otwórz menu g³ówne z ekranu pauzy
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    // Zamknij grê
    public void QuitGame()
    {
        Debug.Log("Quitting game ...");
        Application.Quit();
    }
}
