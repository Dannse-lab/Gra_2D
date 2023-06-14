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
        Cursor.visible = false; // Cursor disabled
    }
    // Zatrzymaj gr�
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true; // Cursor enabled
    }
    // Otw�rz menu g��wne z ekranu pauzy
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    // Zamknij gr�
    public void QuitGame()
    {
        Debug.Log("Quitting game ...");
        Application.Quit();
    }
}
