using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private int maxHealth; // Players max health
    [SerializeField] private HealthBar healthBar; // Reference to healthbar object
    [SerializeField] private Animator anim; // Reference to players animations
    private int currentHealth; // Players current health

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration; // Duration of Players invulnerability
    [SerializeField] private int numberOfFlashes; // How many times Player is gonna flash red after getting hurt
    [SerializeField] private SpriteRenderer spriteRender; // Sprite Render

    [Header("Starting Point")]
    [SerializeField] private GameObject player; // Reference to player object
    [SerializeField] private float startX; // Player's starting x coordinate
    [SerializeField] private float startY; // Player's starting y coordinate


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Taking damage whlie space is pressed for tetsing purposes
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Subtracting damage value from health
        healthBar.SetHealth(currentHealth); // Updating health bar
        if(currentHealth > 0)
        {
            anim.SetTrigger("Hurt"); // Triggering "Hurt" animation
            StartCoroutine(Invunerability()); // Starting iframes function
        }
        else
        {
            anim.SetTrigger("Hurt"); // Triggering "Hurt" animation
            Die(); // Player dies
        }
    }

    void Die()
    {
        currentHealth = maxHealth; // Refilling health
        healthBar.SetHealth(currentHealth); // Updating health bar
        player.transform.position = new Vector2(startX, startY); // Taking Player back to start of level
    }

    public IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true); // Ignores collision between layers (Player/Enemy)
        //
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRender.color = new Color(1, 0, 0, 0.5f); // Changing Players color to red
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2)); // Color change duration
            spriteRender.color = Color.white; // Changing Players color to normal
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2)); // Color change duration
        }
        Physics2D.IgnoreLayerCollision(10, 11, false); // Stops ignoring collision
    }
}