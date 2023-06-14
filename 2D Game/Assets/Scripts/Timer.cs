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
        seconds += 1 * Time.deltaTime; // Counting seconds
        if(seconds>=60) // Transfering seconds to minutes and seconds
        {
            seconds -= 60;
            minutes++;
        }
        timer = minutes.ToString("0") + ":" + seconds.ToString("00.0"); // Transfering time to text
        m_textMeshPro.SetText(timer); // Displaying text
    }
}