using UnityEngine;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_textMeshPro; // Text Reference
    [HideInInspector] public float seconds = 0; // Timer seconds
    [HideInInspector] public float minutes = 0; // Timer minutes
    [HideInInspector] public static string timer; // Time value (minutes:seconds.miliseconds)

    void Update()
    {
        seconds += 1 * Time.deltaTime; // Adding time to seconds
        if(seconds>=60)
        {
            seconds -= 60;
            minutes++;
        }
        timer = minutes.ToString("0") + ":" + seconds.ToString("00.0");
        m_textMeshPro.SetText(timer); // Setting text to time
    }
}