using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [HideInInspector] public static int gems = 0; // Number of collected gems
    [HideInInspector] public static int cherrys = 0; // Number of collected cherrys
    [SerializeField] private TextMeshProUGUI gemCount; // Text displaying number of collected gems

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            gems++;
            gemCount.text = gems.ToString();
        }
        else if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherrys++;
            this.gameObject.GetComponent<PlayerHealth>().Heal(1);
        }
    }
}