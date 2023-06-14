using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [HideInInspector] public static int gems = 0; // Number of collected gems
    [HideInInspector] public static int cherrys = 0; // Number of collected cherrys
    [SerializeField] private TextMeshProUGUI gemCount; // Text displaying number of collected gems

    [Header("SFX")]
    [SerializeField] private AudioSource GemSound; // Picking up gem sound
    [SerializeField] private AudioSource CherrySound; // Picking up cherry sound

    // Function triggered on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collided with gem...
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject); // ...destroy gem
            GemSound.Play(); // ...play gem sound
            gems++; // ...add gem to couter
            gemCount.text = gems.ToString(); // ...update gem count text
        }
        // If collided with cherry...
        else if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject); // ...destroy cherry
            CherrySound.Play(); // ...play cherry sound
            cherrys++; // ...add cherry to counter
            this.gameObject.GetComponent<PlayerHealth>().Heal(1); // ...update cherry count text
        }
    }
}