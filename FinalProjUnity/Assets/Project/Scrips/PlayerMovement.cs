using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this class responsible on the player movement , allow to controll his speed , sprint speed , crouch height and jump height
//and other movement actions
public class PlayerMovement : MonoBehaviour
{
    

    public CharacterController controller;

    public float speed;
    public float gravity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //sprinting
    public bool isSprinting = false;
    public bool isSprintApply = false;
    public float sprintingMultiplier;

    //crouching
    public bool isCrouching = false;
    public float crouchingMulitplier;
    public float crouchingHeight = 1.25f;
    public float standingHeight = 1.7f;

    // Update is called once per frame
    void Update()
    {
      

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if( isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
            isSprintApply = false;
            speed = 3f;
        }

        if(isSprinting && !isSprintApply)
        {
            speed *= sprintingMultiplier;
            isSprintApply = true;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        if (isCrouching)
        {
            controller.height = crouchingHeight;
            speed *= crouchingMulitplier;
        }
        else
        {
            controller.height = standingHeight;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
