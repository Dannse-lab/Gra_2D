using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }
}