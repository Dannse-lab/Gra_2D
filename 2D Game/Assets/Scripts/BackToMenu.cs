using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown) // If any key is pressed...
        {
            SceneManager.LoadScene("Menu"); // ... go back to menu
            Cursor.visible = true; // ...turn cursor visible
        }
    }
}