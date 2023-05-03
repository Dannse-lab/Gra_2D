using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int gemy = 0;
    [SerializeField] private Text gemyText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            gemy++;
            gemyText.text = "Gemy: " + gemy;
        }
    }
}
