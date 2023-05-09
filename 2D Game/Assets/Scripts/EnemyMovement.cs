using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementDistance; // Distance that enemy will travel
    [SerializeField] private float speed; // Speed at which enemy will be moving
    public bool movingRight; // Direction of enemy's movement
    public float leftEdge; // Left movement boundry
    public float rightEdge; // Right movement boundry
    private bool facingRight = true;  // For determining which way the enemy is currently facing
    public bool isAlive = true; // If enemy is alive

    // Function is called when the script instance is being loaded
    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance; // Setting left boundry
        rightEdge = transform.position.x; // Setting left boundry
        Flip(); // Flips the enemy
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
            if(transform.position.x > leftEdge) // Moving right
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,
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
            if (transform.position.x < rightEdge) // Moving right
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
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
