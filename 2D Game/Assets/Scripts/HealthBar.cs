using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // Reference to health bar (slider)

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; // Setting health bar's max value
        slider.value = health; // Setting health bar to max value (filling the health bar)
    }

    // Setting health bars value
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
