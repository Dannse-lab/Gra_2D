using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    [SerializeField] private int damage; // Enemys damage value

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") // If in collision with Player...
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage); // ...subtracts Players health.
        }
    }
}