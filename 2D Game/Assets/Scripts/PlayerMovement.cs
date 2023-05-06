using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller; // Reference to Player movement controlls
    public Animator animator; // Refrence to Player animatior (animations set)

    public float runSpeed = 40f; // Players max speed

    float horizontalMove = 0f; // Players current speed

    bool jump = false;
    bool crouch = false;

    // Checking if...
    void Update()
    {
        // ... right/left button was pressed
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // ... jump button was pressed
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true); // Play jump animaton
        }
        // ... crouch button was pressed
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    // Play crouch animaton
    public void OnCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }

    // Stop playing jump animation
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    // FixedUpdate executes every 0.02 seconds
    void FixedUpdate()
    {
        // Passing inputs to players movement controll
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
