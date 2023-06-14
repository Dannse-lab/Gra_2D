using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loading first level
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit(); // Closing the game
    }
}
