using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonMovement : MonoBehaviour
{
    [SerializeField] private float movementDistance; // Distance that piston will travel
    [SerializeField] private float downSpeed; // Speed at which piston will be moving down
    [SerializeField] private float upSpeed; // Speed at which piston will be moving up
    public bool movingDown; // Direction of piston's movement
    public float upEdge; // Upper movement boundry
    public float downEdge; // Bottom movement boundry

    // Function is called when the script instance is being loaded
    private void Awake()
    {
        upEdge = transform.position.y - movementDistance; // Setting upper boundry
        downEdge = transform.position.y; // Setting bottom boundry
    }

    // Function is called every frame
    private void Update()
    {
        if (movingDown)
        {
            if (transform.position.y > upEdge) // Moving down
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y - downSpeed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingDown = false; // Changing movement direction
            }
        }
        else
        {
            if (transform.position.y < downEdge) // Moving up
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y + upSpeed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingDown = true; // Changing movement direction
            }
        }
    }
}