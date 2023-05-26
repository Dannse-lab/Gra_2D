using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    [HideInInspector] public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject summary;

    // Sprawdza,czy gra jest zatrzymana czy nie, jak nie jest zatrzymana, to toczy si� gra, jak jest zatrzymana, to gra si� zatrzymuje
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
    // Wzn�w gr�
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    // Zatrzymaj gr�
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    // Otw�rz menu g��wne z ekranu pauzy
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    // Zamknij gr�
    public void QuitGame()
    {
        Debug.Log("Quitting game ...");
        Application.Quit();
    }
}
