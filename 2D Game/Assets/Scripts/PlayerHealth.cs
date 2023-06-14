using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private int maxHealth; // Player's max health
    [SerializeField] private HealthBar healthBar; // Reference to healthbar object
    private Animator anim; // Reference to player's animations
    private int currentHealth; // Player's current health

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration; // Duration of Player's invulnerability
    [SerializeField] private int numberOfFlashes; // How many times Player is gonna flash red after getting hurt
    private SpriteRenderer spriteRender; // Sprite Render

    [Header("Starting Point")]
    [SerializeField] private GameObject player; // Reference to player object
    [SerializeField] private float startX; // Player's starting x coordinate
    [SerializeField] private float startY; // Player's starting y coordinate

    [Header ("SFX")]
    [SerializeField] private AudioSource hurtSound; // Player's hurt sound
    [SerializeField] private AudioSource respawnSound; // Player's respawn sound

    // Start is called before the first frame update
    // Loading player's health and animations
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Subtracting damage value from current health
        healthBar.SetHealth(currentHealth); // Updating health bar
        if(currentHealth > 0)
        {
            hurtSound.Play(); // Playing hurt sound
            anim.SetTrigger("Hurt"); // Triggering "Hurt" animation
            StartCoroutine(Invunerability()); // Starting iframes function
        }
        else
        {
            //anim.SetTrigger("Hurt"); // Triggering "Hurt" animation
            Die(); // Player dies
        }
    }

    public void Heal(int heal)
    {
        if (currentHealth<maxHealth)
        {
            currentHealth += heal; // Adding heal value to current health
            healthBar.SetHealth(currentHealth); // Updating health bar
        }
    }

    void Die()
    {
        player.transform.position = new Vector2(startX, startY); // Taking Player back to start of level
        respawnSound.Play(); // Playing respawn sound
        currentHealth = maxHealth; // Refilling health
        healthBar.SetHealth(currentHealth); // Updating health bar
    }

    public IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true); // Ignores collision between layers (Player/Enemy)
        //
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRender.color = new Color(1, 0, 0, 0.5f); // Changing Player's color to red
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2)); // Color change duration
            spriteRender.color = Color.white; // Changing Player's color to normal
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2)); // Color change duration
        }
        Physics2D.IgnoreLayerCollision(10, 11, false); // Stops ignoring collision
    }
}