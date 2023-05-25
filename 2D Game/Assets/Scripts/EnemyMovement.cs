using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float rMovementDistance; // Distance that enemy will travel to the right
    [SerializeField] private float lMovementDistance; // Distance that enemy will travel to the left
    [SerializeField] private float speed; // Speed at which enemy will be moving
    [HideInInspector] public bool movingRight; // Direction of enemy's movement
    [HideInInspector] public float leftEdge; // Left movement boundry
    [HideInInspector] public float rightEdge; // Right movement boundry
    [HideInInspector] private bool facingRight = true;  // For determining which way the enemy is currently facing
    [HideInInspector] public bool isAlive = true; // If enemy is alive

    // Function is called when the script instance is being loaded
    private void Awake()
    {
        leftEdge = transform.position.x - lMovementDistance; // Setting left boundry
        rightEdge = transform.position.x + rMovementDistance; // Setting right boundry
    }

    // Function is called every frame
    private void Update()
    {
        if(!isAlive) // If enemy is not alive destroy him
        {
            Destroy(this.gameObject);
        }
        if(movingRight)
        {
            if(transform.position.x < rightEdge) // Moving right
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
                    transform.position.y, transform.position.z);
            }
            else
            {
                movingRight = false; // Changing movement direction
                Flip(); // Flip the enemy
            }
        }
        else
        {
            if (transform.position.x > leftEdge) // Moving left
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,
                    transform.position.y, transform.position.z);
            }
            else
            {
                movingRight = true; // Changing movement direction
                Flip(); // Flip the enemy
            }
        }
    }

    private void Flip()
    {
        // Switch the way the enemy is labelled as facing.
        facingRight = !facingRight;

        // Multiply the enemy's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}